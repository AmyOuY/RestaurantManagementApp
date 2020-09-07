using RMDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public class FoodData : IFoodData
    {
        private readonly ISqlDataAccess _sql;

        public FoodData(ISqlDataAccess sql)
        {
            _sql = sql;
        }


        public async Task InsertFood(FoodModel food)
        {
            await _sql.SaveData<FoodModel>("Food_Insert", food);
        }


        public async Task<List<FoodModel>> GetAllFoods()
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetAll", new { });

            return results;
        }


        public async Task<List<FoodModel>> GetFoodByType(string foodType)
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetByType", new { foodType });

            return results;
        }


        public async Task<List<FoodModel>> GetFoodByOrder(int orderId)
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetByOrder", new { orderId });

            return results;
        }


        public async Task<FoodModel> GetFoodById(int id)
        {
            var result = await _sql.LoadData<FoodModel, dynamic>("Food_GetById", new { id });

            return result.FirstOrDefault();
        }

        public async Task UpdateFood(FoodModel food)
        {
            
            await _sql.SaveData<FoodModel>("Food_Update", food);
        }


        public async Task DeleteFood(int id)
        {
            await _sql.DeleteData<dynamic>("Food_Delete", new { id });
        }
    }
}
