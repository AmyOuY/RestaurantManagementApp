using Microsoft.Extensions.Configuration;
using RMDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataLibrary.DataAccess
{
    public class OrderData : IOrderData
    {
        private readonly ISqlDataAccess _sql;
        private readonly IFoodData _food;
        private readonly IConfiguration _config;

        public OrderData(ISqlDataAccess sql, IFoodData food, IConfiguration config)
        {
            _sql = sql;
            _food = food;
            _config = config;
        }


        public async Task InsertOrderDetail(OrderDetailModel orderDetail)
        {
            await _sql.SaveData<OrderDetailModel>("OrderDetail_Insert", orderDetail);
        }


        public async Task InsertOrderByTable(int tableId)
        {
            OrderModel order = new OrderModel();
            var results = await _sql.LoadData<OrderDetailModel, dynamic>("OrderDetail_GetByDiningTable", new { DiningTableId = tableId });

            if (results == null) return;

            order.DiningTableId = tableId;
            order.ServerId = results[0].ServerId;

            foreach (var detail in results)
            {
                var food = await _food.GetFoodById(detail.FoodId);
                order.SubTotal += detail.Quantity * food.Price;
            }
                                 
            decimal taxRate = GetTaxRate();
            order.Tax = order.SubTotal * taxRate;
            order.Total = order.SubTotal + order.Tax;

            await _sql.SaveData<OrderModel>("Order_Insert", order);
        }


        public async Task<List<OrderModel>> GetAllOrders()
        {
            var results = await _sql.LoadData<OrderModel, dynamic>("Order_GetAll", new { });

            return results;
        }


        public async Task<OrderModel> GetOrderByTable(int tableId)
        {
            var results = await _sql.LoadData<OrderModel, dynamic>("Order_GetByDiningTable", new { DiningTableId = tableId });

            return results.FirstOrDefault();
        }


        public async Task<List<OrderDetailModel>> GetOrderDetailByDiningTable(int tableId)
        {
            var results = await _sql.LoadData<OrderDetailModel, dynamic>("OrderDetail_GetByDiningTable", new { DiningTableId = tableId });

            return results;
        }


        private decimal GetTaxRate()
        {
            string rateText = _config.GetValue<string>("TaxRate");

            bool isValidTaxRate = decimal.TryParse(rateText, out decimal output);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax rate is not properly set.");
            }

            output = output / 100;

            return output;
        }


        public async Task<OrderDetailModel> GetOrderDetailById(int id)
        {
            var results = await _sql.LoadData<OrderDetailModel, dynamic>("OrderDetail_GetById", new { id });

            return results.FirstOrDefault();
        }


        public async Task<OrderModel> GetOrderById(int id)
        {
            var results = await _sql.LoadData<OrderModel, dynamic>("Order_GetById", new { id });

            return results.FirstOrDefault();
        }

        public async Task UpdateOrderDetail(OrderDetailModel detail)
        {
            await _sql.SaveData<OrderDetailModel>("OrderDetail_Update", detail);
        }


        public async Task UpdateOrder(OrderModel order)
        {
            await _sql.SaveData<OrderModel>("Order_Update", order);
        }


        public async Task DeleteOrderDetail(int id)
        {
            await _sql.DeleteData<dynamic>("OrderDetail_Delete", new { id });
        }


        public async Task DeleteOrder(int id)
        {
            await _sql.DeleteData<dynamic>("Order_Delete", new { id });
        }
    }
}
