using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;

namespace TimeTrackerTutorial.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        ObservableCollection<WorkItem> _workItems;
        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        double _todaysEarnings;
        public double TodaysEarnings
        {
            get => _todaysEarnings;
            set => SetProperty(ref _todaysEarnings, value);
        }
    }
}
