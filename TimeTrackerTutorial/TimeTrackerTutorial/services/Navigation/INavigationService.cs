using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerTutorial.services.Navigation
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
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false);
        
        /// <summary>
        /// Navigation method to pop off the navigation stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
