using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDotnetDemo.Models;

namespace MongoDotnetDemo.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetById(string id);
        Task CreateAsync(Product product);
        Task UpdateAsync(string id, Product product);
        Task DeleteAsync(string id);
    }
}