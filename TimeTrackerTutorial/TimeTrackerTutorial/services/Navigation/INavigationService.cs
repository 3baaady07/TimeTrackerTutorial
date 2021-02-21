using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;

namespace TimeTrackerTutorial.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to push onto the navigation stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false) 
            where TPageModel : PageModelBase;
        
        /// <summary>
        /// Navigation method to pop off the navigation stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
