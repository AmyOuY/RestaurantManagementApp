using Newtonsoft.Json;
using RMUI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class DiningTableAPIintegrationTest
    {
        [Fact]
        public async Task Test_ViewDiningTables()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/diningTable/diningTables");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_InsertDiningTable()
        {
            using (var client = new TestClientProvider().Client)
            {
                var newTable = new DiningTableDisplayModel
                {
                    TableNumber = 10,
                    Seats = 6
                };

                var response = await client.PostAsJsonAsync("/api/diningTable", newTable);

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

    }
}
