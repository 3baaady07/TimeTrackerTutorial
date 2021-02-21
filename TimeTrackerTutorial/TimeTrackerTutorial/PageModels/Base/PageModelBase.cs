using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject
    {
        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// Performs Page Model initialization Asynchronously
        /// </summary>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        public virtual Task InitializeAsync(object navigationData = null)
        {
            return Task.CompletedTask;
        }
    }
}
