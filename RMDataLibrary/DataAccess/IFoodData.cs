using RMDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public interface IFoodData
    {
        Task<List<FoodModel>> GetAllFoods();
        Task<List<FoodModel>> GetFoodByType(string foodType);
        Task<FoodModel> GetFoodById(int id);
        Task InsertFood(FoodModel food);
        Task UpdateFood(FoodModel food);
        Task DeleteFood(int id);
    }
}