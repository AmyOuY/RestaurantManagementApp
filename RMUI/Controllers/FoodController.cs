using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RMDataLibrary.DataAccess;
using RMDataLibrary.Models;
using RMUI.Models;

namespace RMUI.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodData _data;

        public FoodController(IFoodData data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> InsertFood(FoodDisplayModel food)
        {
            if (ModelState.IsValid)
            {
                FoodModel newFood = new FoodModel
                {
                    FoodType = food.FoodType,
                    FoodName = food.FoodName,
                    Price = food.Price
                };

                await _data.InsertFood(newFood);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> ViewFoods()
        {
            var allFoods = await _data.GetAllFoods();

            List<FoodDisplayModel> foods = new List<FoodDisplayModel>();

            foreach (var food in allFoods)
            {
                foods.Add(new FoodDisplayModel
                {
                    Id = food.Id,
                    FoodType = food.FoodType,
                    FoodName = food.FoodName,
                    Price = food.Price
                });
            }

            return View(foods);
        }

      

        public async Task<IActionResult> EditFood(int id)
        {
            FoodModel foundFood = await _data.GetFoodById(id);

            FoodDisplayModel food = new FoodDisplayModel
            {
                Id = id,
                FoodType = foundFood.FoodType,
                FoodName = foundFood.FoodName,
                Price = foundFood.Price
            };

            var p = food.Price;

            return View(food);
        }


        public async Task<IActionResult> UpdateFood(FoodDisplayModel food)
        {
            FoodModel updatedFood = new FoodModel
            {
                Id = food.Id,
                FoodType = food.FoodType,
                FoodName = food.FoodName,
                Price = food.Price
            };


            await _data.UpdateFood(updatedFood);

            return RedirectToAction("ViewFoods");
        }


        public async Task<IActionResult> DeleteFood(int id)
        {
            await _data.DeleteFood(id);

            return RedirectToAction("ViewFoods");
        }
    }
}