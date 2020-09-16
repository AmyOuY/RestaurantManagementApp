using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RMDataLibrary.DataAccess;
using RMDataLibrary.Models;
using RMUI.Models;

namespace RMUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IFoodData _food;
        private readonly IPersonData _people;
        private readonly IDiningTableData _table;
        private readonly IOrderData _order;

        public OrderController(IFoodData food, IPersonData people, IDiningTableData table, IOrderData order)
        {
            _food = food;
            _people = people;
            _table = table;
            _order = order;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<List<SelectListItem>> GetAllTables()
        {
            var tables = await _table.GetAllTables();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var table in tables)
            {
                list.Add(new SelectListItem
                {
                    Text = table.TableNumber.ToString(),
                    Value = table.Id.ToString()
                });
            }

            return list;
        }


        public async Task<List<SelectListItem>> GetAllServers()
        {
            var persons = await _people.GetAllPeople();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var person in persons)
            {
                list.Add(new SelectListItem
                {
                    Text = person.FullName,
                    Value = person.Id.ToString()
                });
            }

            return list;
        }


        public async Task<List<SelectListItem>> GetFoodTypes()
        {
            var foodTypes = await _food.GetAllFoodTypes();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var foodType in foodTypes)
            {
                list.Add(new SelectListItem
                {
                    Text = foodType.FoodType,
                    Value = foodType.Id.ToString()
                });
            }

            return list;
        }


        public async Task<JsonResult> GetFoodsByTypeId(int typeId)
        {
            var foods = await _food.GetFoodByTypeId(typeId);
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var food in foods)
            {
                list.Add(new SelectListItem
                {
                    Text = food.FoodName,
                    Value = food.Id.ToString()
                });
            }

            return Json(list);
        }



        public async Task<JsonResult> GetFoodById(int id)
        {
            var food = await _food.GetFoodById(id);
            return Json(food);
        }


        public async Task<IActionResult> CreateOrder()
        {
            var tables = await GetAllTables();
            ViewBag.TableList = tables;

            var servers = await GetAllServers();
            ViewBag.ServerList = servers;

            var foods = await GetFoodTypes();
            ViewBag.FoodTypeList = foods;

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderFillInModel order)
        {
            if (ModelState.IsValid)
            {
                OrderDetailModel detail = new OrderDetailModel
                {
                    DiningTableId = order.TableNumber,
                    ServerId = int.Parse(order.Server),
                    FoodId = int.Parse(order.FoodName),
                    Quantity = order.Quantity
                };

                await _order.InsertOrderDetail(detail);
            }

            var tables = await GetAllTables();
            ViewBag.TableList = tables;

            var servers = await GetAllServers();
            ViewBag.ServerList = servers;

            var foods = await GetFoodTypes();
            ViewBag.FoodTypeList = foods;

            return View();
        }


        private async Task<bool> IsValidTableNumber (int tableNumber)
        {
            var tables = await _table.GetAllTables();
            HashSet<int> tableNumbers = new HashSet<int>(tables.Select(x => x.TableNumber));
            return tableNumbers.Contains(tableNumber);
        }

 

        [HttpPost]
        public async Task<IActionResult> ViewOrderByTable(int tableNumber)
        {
            if (await IsValidTableNumber(tableNumber) == false)
            {
                return RedirectToAction("TableNotExistError", "Home");
            }

            var table = await _table.GetTableByTableNumber(tableNumber);
            var displayDetails = new List<OrderDetailDisplayModel>();
            var orderDetails = await _order.GetOrderDetailByDiningTable(table.Id);

            if (orderDetails == null)
            {
                return RedirectToAction("NoOrderError", "Home");
            }
            else
            {
                var server = await _people.GetPersonById(orderDetails[0].ServerId);

                foreach (var detail in orderDetails)
                {
                    var food = await _food.GetFoodById(detail.FoodId);

                    displayDetails.Add(new OrderDetailDisplayModel
                    {
                        Id = detail.Id,
                        TableNumber = tableNumber,
                        Server = server.FullName,
                        FoodName = food.FoodName,
                        Price = food.Price,
                        Quantity = detail.Quantity,
                        OrderDate = detail.OrderDate
                    });
                }
                return View(displayDetails);
            }
        }


        [HttpPost]
        public async Task<IActionResult> SaveOrderByTable(int tableNumber)
        {
            if (await IsValidTableNumber(tableNumber) == false)
            {
                return RedirectToAction("TableNotExistError", "Home");
            }

            var orderList = await _order.GetAllOrders();           
            var table = await _table.GetTableByTableNumber(tableNumber);

            foreach (var order in orderList)
            {
                if (order.DiningTableId == table.Id && order.BillPaid == false)
                {
                    return RedirectToAction("PlaceOrderError", "Home");
                }
            }

            await _order.InsertOrderByTable(table.Id);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> ViewOrders()
        {
            var orderList = await _order.GetAllOrders();
            List<OrderDisplayModel> orders = new List<OrderDisplayModel>();
            foreach (var order in orderList)
            {
                var table = await _table.GetTableById(order.DiningTableId);
                var server = await _people.GetPersonById(order.ServerId);

                orders.Add(new OrderDisplayModel
                {
                    Id = order.Id,
                    TableNumber = table.TableNumber,
                    Server = server.FullName,
                    SubTotal = order.SubTotal,
                    Tax = order.Tax,
                    Total = order.Total,
                    CreatedDate = order.CreatedDate,
                    BillPaid = order.BillPaid
                });
            }

            return View(orders);
        }


        public IActionResult SearchOrder()
        {
            return View();
        }


        public async Task<IActionResult> EditOrderDetail(int id)
        {
            var detail = await _order.GetOrderDetailById(id);
            var table = await _table.GetTableById(detail.DiningTableId);
            var server = await _people.GetPersonById(detail.ServerId);
            var food = await _food.GetFoodById(detail.FoodId);

            OrderDetailDisplayModel displayDetail = new OrderDetailDisplayModel
            {
                Id = id,
                TableNumber = table.TableNumber,
                Server = server.FullName,
                FoodName = food.FoodName,
                Price = food.Price,
                Quantity = detail.Quantity,
                OrderDate = detail.OrderDate
            };

            return View(displayDetail);
        }


        public async Task<IActionResult> UpdateOrderDetail(OrderDetailDisplayModel displayDetail)
        {
            var table = await _table.GetTableByTableNumber(displayDetail.TableNumber);
            string[] fullName = displayDetail.Server.Split(" ");
            var server = await _people.GetPersonByFullName(fullName[0], fullName[1]);
            var food = await _food.GetFoodByName(displayDetail.FoodName);

            OrderDetailModel orderDetail = new OrderDetailModel
            {
                Id = displayDetail.Id,
                DiningTableId = table.Id,
                ServerId = server.Id,
                FoodId = food.Id,
                Quantity = displayDetail.Quantity,
                OrderDate = displayDetail.OrderDate
            };

            await _order.UpdateOrderDetail(orderDetail);

            var oldOrder = await _order.GetOrderByTable(table.Id);
            await _order.DeleteOrder(oldOrder.Id);
            await _order.InsertOrderByTable(table.Id);

            //return RedirectToAction("SaveOrderByTable", new { table.TableNumber });
            return RedirectToAction("OrderByTableDetail", new { displayDetail.Id });
        }


        public async Task<IActionResult> OrderByTableDetail(int id)
        {
            var detail = await _order.GetOrderDetailById(id);
            var table = await _table.GetTableById(detail.DiningTableId);
            var server = await _people.GetPersonById(detail.ServerId);
            var food = await _food.GetFoodById(detail.FoodId);

            OrderDetailDisplayModel displayDetail = new OrderDetailDisplayModel
            {
                Id = id,
                TableNumber = table.TableNumber,
                Server = server.FullName,
                FoodName = food.FoodName,
                Price = food.Price,
                Quantity = detail.Quantity,
                OrderDate = detail.OrderDate
            };

            return View(displayDetail);

        }


        public async Task<IActionResult> EditOrder(int id)
        {
            var order = await _order.GetOrderById(id);
            var table = await _table.GetTableById(order.DiningTableId);
            var server = await _people.GetPersonById(order.ServerId);

            OrderDisplayModel displayOrder = new OrderDisplayModel
            {
                Id = id,
                TableNumber = table.TableNumber,
                Server = server.FullName,
                SubTotal = order.SubTotal,
                Tax = order.Tax,
                Total = order.Total,
                CreatedDate = order.CreatedDate,
                BillPaid = order.BillPaid
            };

            return View(displayOrder);
        }


        public async Task<IActionResult> UpdateOrder(OrderDisplayModel display)
        {
            var table = await _table.GetTableByTableNumber(display.TableNumber);
            string[] fullName = display.Server.Split(" ");
            var server = await _people.GetPersonByFullName(fullName[0], fullName[1]);

            OrderModel order = new OrderModel
            {
                Id = display.Id,
                DiningTableId = table.Id,
                ServerId = server.Id,
                SubTotal = display.SubTotal,
                Tax = display.Tax,
                Total = display.Total,
                CreatedDate = display.CreatedDate,
                BillPaid = display.BillPaid
            };

            await _order.UpdateOrder(order);

            return RedirectToAction("ViewOrders");
        }



        public async Task<IActionResult> TableOrdersDetails(int id)
        {
            var order = await _order.GetOrderById(id);
            var table = await _table.GetTableById(order.DiningTableId);
            var orderDetails = await _order.GetOrderDetailByDiningTable(table.Id);
            var displayDetails = new List<OrderDetailDisplayModel>();

            if (orderDetails == null)
            {
                return RedirectToAction("NoOrderError", "Home");
            }
            else
            {
                var server = await _people.GetPersonById(orderDetails[0].ServerId);

                foreach (var detail in orderDetails)
                {
                    var food = await _food.GetFoodById(detail.FoodId);

                    displayDetails.Add(new OrderDetailDisplayModel
                    {
                        Id = detail.Id,
                        TableNumber = table.TableNumber,
                        Server = server.FullName,
                        FoodName = food.FoodName,
                        Price = food.Price,
                        Quantity = detail.Quantity,
                        OrderDate = detail.OrderDate
                    });
                }
                return View(displayDetails);
            }
        }


        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _order.DeleteOrderDetail(id);

            return RedirectToAction("ViewOrders");
        }


        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _order.DeleteOrder(id);

            return RedirectToAction("ViewOrders");
        }
    }
}