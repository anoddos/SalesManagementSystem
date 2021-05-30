using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        bool Create(Sale sale);
        bool Delete(long id);
        IEnumerable<Sale> Read();
        bool Update(Sale sale);
    }
}