using MudBlazor;
using System.Collections.Generic;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        public string[] GetLabels()
        {
            return new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
        }

        public List<ChartSeries> GetDatasets()
        {
            return new List<ChartSeries>
            {
                new ChartSeries
                {
                    Name = "Savings",
                    Data = new double[] { 1000, 1200, 1500, 1300, 1700, 1900 }
                },
                new ChartSeries
                {
                    Name = "Loans",
                    Data = new double[] { 500, 700, 600, 800, 900, 1000 }
                }
            };
        }

        public int GetTotalMembers()
        {
            return 150; // Example static data
        }

        public decimal GetTotalLoans()
        {
            return 500000m; // Example static data
        }

        public decimal GetTotalSavings()
        {
            return 750000m; // Example static data
        }

        public string[] GetLoanDistributionLabels()
        {
            return new[] { "Personal", "Business", "Agriculture", "Education" };
        }

        public double[] GetLoanDistributionData()
        {
            return new double[] { 40, 25, 20, 15 };
        }

        public string[] GetMonthlyRepaymentLabels()
        {
            return new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
        }

        public double[] GetMonthlyRepaymentData()
        {
            return new double[] { 10000, 12000, 15000, 13000, 17000, 19000 };
        }
    }
}
