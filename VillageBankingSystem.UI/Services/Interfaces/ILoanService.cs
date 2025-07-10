using System.Collections.Generic;
using VillageBankingSystem.Shared.Models;

namespace VillageBankingSystem.UI.Services.Interfaces
{
    public interface ILoanService
    {
        List<LoanRecord> GetLoanProjections();
    }
}
