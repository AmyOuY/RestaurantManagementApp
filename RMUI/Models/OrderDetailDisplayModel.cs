using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMUI.Models
{
    public class OrderDetailDisplayModel
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string Server { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
