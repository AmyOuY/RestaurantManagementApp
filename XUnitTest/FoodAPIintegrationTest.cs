using RMUI.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class FoodAPIintegrationTest
    {      
        [Fact]
        public async Task Test_GetFoodTypes()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/food/foodTypes");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_GetFoods()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await (client.GetAsync("/api/food/foods"));

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Test_InsertFoodType()
        {
            using (var client = new TestClientProvider().Client)
            {
                var newFoodType = new FoodTypeDisplayModel
                {
                    FoodType = "BBQ"
                };

                var response = await client.PostAsJsonAsync("/api/foodType", newFoodType);

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_InsertFood()
        {
            using (var client = new TestClientProvider().Client)
            {
                var newFood = new FoodDisplayModel
                {
                    FoodType = "BBQ",
                    FoodName = "BBQ duck",
                    Price = 6.5M,
                    TypeId = 9
                };

                var response = await client.PostAsJsonAsync("/api/food", newFood);

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
