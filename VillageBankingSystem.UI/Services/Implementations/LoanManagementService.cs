using System;
using System.Collections.Generic;
using System.Linq;
using VillageBankingSystem.Shared.Models;
using VillageBankingSystem.UI.Services.Interfaces;

namespace VillageBankingSystem.UI.Services.Implementations
{
    public class LoanManagementService : ILoanManagementService
    {
        private readonly List<Loan> _loans = new List<Loan>();
        private readonly List<Repayment> _repayments = new List<Repayment>();

        public List<Loan> GetLoans()
        {
            return _loans;
        }

        public List<Repayment> GetRepayments()
        {
            return _repayments;
        }

        public void IssueLoan(string member, decimal principal)
        {
            var loan = new Loan
            {
                Member = member,
                Principal = principal,
                InterestRate = 0.12m,
                MonthsPaid = 0,
                TotalMonths = 12,
                RemainingPrincipal = principal
            };
            _loans.Add(loan);
        }

        public void MakeRepayment(string member, decimal amount)
        {
            var loan = _loans.FirstOrDefault(l => l.Member == member && l.RemainingPrincipal > 0);
            if (loan != null)
            {
                decimal interestDue = loan.RemainingPrincipal * loan.InterestRate;
                decimal principalPayment = amount - interestDue;
                if (principalPayment < 0)
                {
                    interestDue = amount;
                    principalPayment = 0;
                }
                loan.RemainingPrincipal -= principalPayment;
                loan.MonthsPaid++;
                _repayments.Add(new Repayment
                {
                    Member = member,
                    Amount = amount,
                    Date = DateTime.Now
                });
            }
        }
    }
}
