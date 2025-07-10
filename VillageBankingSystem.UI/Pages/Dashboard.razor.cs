using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Charts;
using VillageBankingSystem.UI.Services.Interfaces;
using VillageBankingSystem.UI.Services.Implementations;
using System.Collections.Generic;

namespace VillageBankingSystem.UI.Pages
{
    public partial class Dashboard : ComponentBase
    {
        private string[] _labels = Array.Empty<string>();
        private List<ChartSeries> _chartSeries = new();

        private string[] _loanDistributionLabels = Array.Empty<string>();
        private List<ChartSeries> _loanDistributionSeries = new();

        private string[] _monthlyRepaymentLabels = Array.Empty<string>();
        private List<ChartSeries> _monthlyRepaymentSeries = new();

        protected int TotalMembers { get; set; }
        protected decimal TotalLoans { get; set; }
        protected decimal TotalSavings { get; set; }

        [Inject]
        public IDashboardService? DashboardService { get; set; }

        protected override void OnInitialized()
        {
            if (DashboardService != null)
            {
                // Existing financial overview data
                _labels = DashboardService.GetLabels();
                var datasets = DashboardService.GetDatasets();
                foreach (var dataset in datasets)
                {
                _chartSeries.Add(new ChartSeries
                {
                    Name = dataset.Name,
                    Data = dataset.Data
                });
                }

                // New: Fetch summary metrics
                TotalMembers = DashboardService.GetTotalMembers();
                TotalLoans = DashboardService.GetTotalLoans();
                TotalSavings = DashboardService.GetTotalSavings();

                // New: Loan distribution data
                _loanDistributionLabels = DashboardService.GetLoanDistributionLabels();
                var loanDistData = DashboardService.GetLoanDistributionData();
                _loanDistributionSeries.Add(new ChartSeries
                {
                    Name = "Loan Distribution",
                    Data = loanDistData
                });

                // New: Monthly repayment data
                _monthlyRepaymentLabels = DashboardService.GetMonthlyRepaymentLabels();
                var monthlyRepaymentData = DashboardService.GetMonthlyRepaymentData();
                _monthlyRepaymentSeries.Add(new ChartSeries
                {
                    Name = "Monthly Repayments",
                    Data = monthlyRepaymentData
                });
            }
        }
    }
}
