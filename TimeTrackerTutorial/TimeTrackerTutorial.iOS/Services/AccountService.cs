using Firebase.Auth;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.iOS.Services;
using TimeTrackerTutorial.Services.Account;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace TimeTrackerTutorial.iOS.Services
{
    public class AccountService : IAccountService
    {
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
            throw new NotImplementedException();
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
    }
}