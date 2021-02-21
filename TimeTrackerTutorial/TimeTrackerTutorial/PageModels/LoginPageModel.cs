using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Navigation;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _signInCommand;
        private INavigationService _navigationService;
        private IAccountService _accountService;
        private string _username;
        private string _password;

        public ICommand LoginCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }
        
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            // Init our login command
            LoginCommand = new Command(DoLoginAction);
        }

        /// <summary>
        /// Perform login validation and navigation if applicable
        /// </summary>
        /// <param name="obj"></param>
        private async void DoLoginAction(object obj)
        {
            bool loginAttempt = await _accountService.LoginAsync(Username, Password);

            if (loginAttempt)
            {
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                //TODO: Display an alert for faliure
            }
        }
    }


}
