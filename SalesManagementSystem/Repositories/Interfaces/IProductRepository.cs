using System.Collections.Generic;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface IProductRepository
    {
        int Create(Product product);
        int Delete(long id);
        IEnumerable<Product> Read();
        int Update(Product product);
    }
}