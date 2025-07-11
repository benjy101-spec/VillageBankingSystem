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
        _labels = DashboardService.GetLabels() ?? new string[] { "Jan", "Feb", "Mar", "Apr", "May" };
        var datasets = DashboardService.GetDatasets();
        if (datasets == null || datasets.Count == 0)
        {
            _chartSeries = new List<ChartSeries>
            {
                new ChartSeries { Name = "Savings", Data = new double[] { 1000, 1200, 1500, 1300, 1600 } },
                new ChartSeries { Name = "Loans", Data = new double[] { 800, 900, 1100, 1050, 1150 } }
            };
        }
        else
        {
            foreach (var dataset in datasets)
            {
                _chartSeries.Add(new ChartSeries
                {
                    Name = dataset.Name,
                    Data = dataset.Data
                });
            }
        }

        // New: Fetch summary metrics
        TotalMembers = DashboardService.GetTotalMembers();
        TotalLoans = DashboardService.GetTotalLoans();
        TotalSavings = DashboardService.GetTotalSavings();

        // New: Loan distribution data
        _loanDistributionLabels = DashboardService.GetLoanDistributionLabels() ?? new string[] { "Personal", "Business", "Education" };
        var loanDistData = DashboardService.GetLoanDistributionData();
        if (loanDistData == null || loanDistData.Length == 0)
        {
            _loanDistributionSeries = new List<ChartSeries>
            {
                new ChartSeries { Name = "Loan Distribution", Data = new double[] { 40, 35, 25 } }
            };
        }
        else
        {
            _loanDistributionSeries.Add(new ChartSeries
            {
                Name = "Loan Distribution",
                Data = loanDistData
            });
        }

        // New: Monthly repayment data
        _monthlyRepaymentLabels = DashboardService.GetMonthlyRepaymentLabels() ?? new string[] { "Jan", "Feb", "Mar", "Apr", "May" };
        var monthlyRepaymentData = DashboardService.GetMonthlyRepaymentData();
        if (monthlyRepaymentData == null || monthlyRepaymentData.Length == 0)
        {
            _monthlyRepaymentSeries = new List<ChartSeries>
            {
                new ChartSeries { Name = "Monthly Repayments", Data = new double[] { 500, 600, 700, 650, 720 } }
            };
        }
        else
        {
            _monthlyRepaymentSeries.Add(new ChartSeries
            {
                Name = "Monthly Repayments",
                Data = monthlyRepaymentData
            });
        }
    }
}
    }
}
