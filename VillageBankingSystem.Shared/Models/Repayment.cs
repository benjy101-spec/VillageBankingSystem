using System;

namespace VillageBankingSystem.Shared.Models
{
    public class Repayment
    {
        public string Member { get; set; } = string.Empty; // or make it nullable: string? Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
