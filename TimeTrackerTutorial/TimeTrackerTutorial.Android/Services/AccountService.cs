using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Java.Util.Concurrent;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Services.Account;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class AccountService : PhoneAuthProvider.OnVerificationStateChangedCallbacks, IAccountService
    {
        private TaskCompletionSource<bool> _phoneAuthTcs;
        private string _verificationID;
        const int OTP_TIMEOUT = 30; // seconds

        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username,password)
                .ContinueWith((task) => OnAuthCompleted(task, tcs));

            return tcs.Task;
        }

        public override void OnVerificationCompleted(PhoneAuthCredential credential)
        {
            System.Diagnostics.Debug.WriteLine("PhoneAuthCredential created Automatically");
        }

        public override void OnVerificationFailed(FirebaseException exception)
        {
            System.Diagnostics.Debug.WriteLine("Verification Failed: " + exception.Message);
            _phoneAuthTcs?.TrySetResult(false);
        }

        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        {
            base.OnCodeSent(verificationId, forceResendingToken);
            _verificationID = verificationId;
            _phoneAuthTcs?.TrySetResult(true);
        }

        public Task<bool> SendOtpCodeAsync(string phoneNumber)
        {
            _phoneAuthTcs = new TaskCompletionSource<bool>();
            PhoneAuthProvider.Instance.VerifyPhoneNumber(
                phoneNumber,
                OTP_TIMEOUT,
                TimeUnit.Seconds,
                Platform.CurrentActivity,
                this);
            return _phoneAuthTcs.Task;
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                //Something went wrong
                tcs.SetResult(false);
                return;
            }
            _verificationID = null;
            tcs.SetResult(true);
        }

        public Task<bool> VerifyOtpCodeAsync(string code)
        {
            if(!string.IsNullOrWhiteSpace(_verificationID))
            {
                var credential = PhoneAuthProvider.GetCredential(_verificationID, code);
                var tcs = new TaskCompletionSource<bool>();
                FirebaseAuth.Instance.SignInWithCredentialAsync(credential)
                    .ContinueWith((task) => OnAuthCompleted(task, tcs));
                return tcs.Task;
            }
            return Task.FromResult(false);
        }
    }
}