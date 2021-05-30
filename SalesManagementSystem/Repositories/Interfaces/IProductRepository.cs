using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface IProductRepository
    {
        bool Create(Product product);
        bool Delete(long id);
        IEnumerable<Product> Read();
        bool Update(Product product);
    }
}