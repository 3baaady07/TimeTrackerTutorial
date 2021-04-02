﻿using Firebase.Auth;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.iOS.Services;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.Services.Account;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace TimeTrackerTutorial.iOS.Services
{
    public class AccountService : IAccountService
    {
        private TaskCompletionSource<bool> _phoneAuthTcs;
        private string _verificationId;

        public AccountService()
        {
        }

        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            Auth.DefaultInstance.SignInWithPasswordAsync(username, password)
                .ContinueWith((task) => OnAuthCompleted(task, tcs));

            return tcs.Task;
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            _phoneAuthTcs = new TaskCompletionSource<bool>();

            PhoneAuthProvider.DefaultInstance.VerifyPhoneNumber(
                phoneNumber,
                null,
                new VerificationResultHandler(OnVerificationResult));

            return _phoneAuthTcs.Task;
        }

        private void OnVerificationResult(string verificationId, NSError error)
        {
            if(error != null)
            {
                // Something went wrong
                _phoneAuthTcs?.TrySetResult(false);
                return;
            }
            _verificationId = verificationId;
            _phoneAuthTcs?.TrySetResult(true);
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            var tcs = new TaskCompletionSource<bool>();
            var credential = PhoneAuthProvider.DefaultInstance.GetCredential(_verificationId, code);
            Auth.DefaultInstance.SignInWithCredentialAsync(credential)
                .ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if(task.IsCanceled || task.IsFaulted)
            {
                //Something went wrong
                tcs.SetResult(false);
                return;
            }
            // user is logged in
            tcs.SetResult(true);
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<AuthenticatedUser>();

            Firebase.CloudFirestore.Firestore.SharedInstance
                .GetCollection("user")
                .GetDocument(Auth.DefaultInstance.CurrentUser.Uid)
                .GetDocument((snapshot, error) =>
                {
                    if (error != null)
                    {
                        // somthing went wrong
                        tcs.TrySetResult(default(AuthenticatedUser));
                        return;
                    }
                    tcs.TrySetResult(new AuthenticatedUser
                    {
                        Id = snapshot.Id,
                        FirstName = snapshot.GetValue(new NSString("FirstName")).ToString(),
                        LastName = snapshot.GetValue(new NSString("LastName")).ToString()
                    });
                });

            return tcs.Task;
        }
    }
}