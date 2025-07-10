using System.Collections.Generic;
using MudBlazor;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface IDashboardService
    {
        string[] GetLabels();
        List<ChartSeries> GetDatasets();

        int GetTotalMembers();
        decimal GetTotalLoans();
        decimal GetTotalSavings();

        string[] GetLoanDistributionLabels();
        double[] GetLoanDistributionData();

        string[] GetMonthlyRepaymentLabels();
        double[] GetMonthlyRepaymentData();
    }
}
