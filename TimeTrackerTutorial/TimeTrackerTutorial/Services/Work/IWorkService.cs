﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Services.Work
{
    public interface IWorkService
    {
        Task<bool> LogWorkAsync(WorkItem item);
        Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync();
    }
}