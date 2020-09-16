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

        // Insert food into database
        public async Task InsertFood(FoodModel food)
        {
            await _sql.SaveData<FoodModel>("Food_Insert", food);
        }


        // Get all foods info from database
        public async Task<List<FoodModel>> GetAllFoods()
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetAll", new { });

            return results;
        }


        public async Task InsertFoodType(FoodTypeModel foodType)
        {
            await _sql.SaveData<FoodTypeModel>("FoodType_Insert", foodType);
        }


        public async Task<List<FoodTypeModel>> GetAllFoodTypes()
        {
            var results = await _sql.LoadData<FoodTypeModel, dynamic>("FoodType_GetAll", new { });

            return results;
        }


        public async Task<List<FoodModel>> GetFoodByTypeId(int typeId)
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetByTypeId", new { typeId });

            return results;
        }

        

        // Get specific food info with Id = id
        public async Task<FoodModel> GetFoodById(int id)
        {
            var result = await _sql.LoadData<FoodModel, dynamic>("Food_GetById", new { id });

            return result.FirstOrDefault();
        }


        public async Task<int> GetTypeIdByFoodType(string foodType)
        {
            var results = await _sql.LoadData<int, dynamic>("Food_GetTypeIdByFoodType", new { foodType });

            return results.FirstOrDefault();
        }


        public async Task<FoodModel> GetFoodByName(string foodName)
        {
            var results = await _sql.LoadData<FoodModel, dynamic>("Food_GetByName", new { FoodName = foodName });

            return results.FirstOrDefault();
        }


        // Update food info in the database
        public async Task UpdateFood(FoodModel food)
        {           
            await _sql.SaveData<FoodModel>("Food_Update", food);
        }


        // Delete specific food from database with Id = id
        public async Task DeleteFood(int id)
        {
            await _sql.DeleteData<dynamic>("Food_Delete", new { id });
        }
    }
}
