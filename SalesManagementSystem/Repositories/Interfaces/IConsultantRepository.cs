using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface IConsultantRepository
    {
        bool Create(Consultant consultant);
        bool Update(Consultant consultant);
        IEnumerable<Consultant> Read();
        bool Delete(long id);
    }
}