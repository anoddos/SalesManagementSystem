using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface IConsultantRepositoy
    {
        int Create(Consultant consultant);
        int Update(Consultant consultant);
        IEnumerable<Sale> Read();
        int Delete(long id);
    }
}