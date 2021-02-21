using System;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerTutorial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<LoginPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
