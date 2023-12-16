using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDotnetDemo.Models;

namespace MongoDotnetDemo.Services
{
    public class CategoryService :  ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        public CategoryService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _categoryCollection = mongoDatabase.GetCollection<Category>
                (dbSettings.Value.CategoriesCollectionName);
        }

        // public async Task<IEnumerable<Category>> GetAllAsync()
        // {
        //     var categories = _categoryCollection.Find(_ => true).ToListAsync();
        //     return categories;
        // }
        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _categoryCollection.Find(_ => true).ToListAsync();

        public async Task<Category> GetById(string id) =>
            await _categoryCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category category) =>
            await _categoryCollection.InsertOneAsync(category);

        public async Task UpdateAsync(string id, Category category) =>
            await _categoryCollection
            .ReplaceOneAsync(a => a.Id == id, category);

        public async Task DeleteAsync(string id) => 
            await _categoryCollection.DeleteOneAsync(a => a.Id == id);
    }
}