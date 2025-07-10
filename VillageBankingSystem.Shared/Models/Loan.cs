namespace VillageBankingSystem.Shared.Models
{
    public class Loan
    {
        public string Member { get; set; }
        public decimal Principal { get; set; }
        public decimal InterestRate { get; set; }
        public int MonthsPaid { get; set; }
        public int TotalMonths { get; set; }
        public decimal RemainingPrincipal { get; set; }
    }
}
