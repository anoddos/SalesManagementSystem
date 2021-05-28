using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        int Create(Sale sale);
        int Delete(long id);
        IEnumerable<Sale> Read();
        int Update(Sale sale);
    }
}