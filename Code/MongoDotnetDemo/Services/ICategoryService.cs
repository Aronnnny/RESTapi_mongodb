using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDotnetDemo.Models;

namespace MongoDotnetDemo.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetById(string id);
        Task CreateAsync(Category category);
        Task UpdateAsync(string id, Category category);
        Task DeleteAsync(string id);
    }
}