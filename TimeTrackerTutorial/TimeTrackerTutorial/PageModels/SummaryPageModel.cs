using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Statement;

namespace TimeTrackerTutorial.PageModels
{
    public class SummaryPageModel : PageModelBase
    {
        private readonly IStatementService _statementService;

        public SummaryPageModel(IStatementService statementService)
        {
            _statementService = statementService;
        }

        public override async Task InitializeAsync(object navigationData = null)
        {
            Statements = await _statementService.GetStatementHistoryAsync()

            await base.InitializeAsync(navigationData);
        }

        string _currentPayDateRange;
        public string CurrentPayDateRange 
        { 
            get => _currentPayDateRange; 
            set => SetProperty(ref _currentPayDateRange, value); 
        }

        double _currentPeriodEarnings;
        public double CurrentPeriodEarnings
        {
            get => _currentPeriodEarnings;
            set => SetProperty(ref _currentPeriodEarnings, value);
        }

        DateTime _currentPeriodPayDate;
        public DateTime CurrentPeriodPayDate
        {
            get => _currentPeriodPayDate;
            set => SetProperty(ref _currentPeriodPayDate, value);
        }

        private List<PayStatement> _statements;
        public List<PayStatement> Statements
        {
            get => _statements;
            set => SetProperty(ref _statements, value);
        }
    }
}
