using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsingSQLite.Models;

namespace UsingSQLite.Services
{
    public class SQLiteService
    {
        readonly SQLiteAsyncConnection _database;
        public SQLiteService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FlowerType>().Wait();
            _database.CreateTableAsync<Flower>().Wait();
        }

        public Task<List<FlowerType>> GetListFlowerType()
        {
            return _database.Table<FlowerType>().ToListAsync();
        }

        public Task<List<Flower>> GetListFlower()
        {
            return _database.Table<Flower>().ToListAsync();
        }

        public Task<FlowerType> GetFlowerType(int id) 
        {
            return _database.Table<FlowerType>().Where(i => i.FlowerTypeID == id).FirstOrDefaultAsync();
        }

        public async Task InsertFlowerType(FlowerType flowerType)
        {
            if(flowerType.FlowerTypeID == 0)
            {
                await _database.InsertAsync(flowerType);
            }
            else
            {
                await _database.UpdateAsync(flowerType);
            }
        }

        public async Task InsertFlower(Flower flower)
        {
            if (flower.FlowerID == 0)
            {
                await _database.InsertAsync(flower);
            }
            else
            {
                await _database.UpdateAsync(flower);
            }
        }

        public Task<List<Flower>> GetListFlowerByFlowerType(int id)
        {
            return _database.Table<Flower>().Where(i => i.FlowerTypeID == id).ToListAsync();
        }
    }
}
