using System;
using System.Collections.Generic;
using System.Text;

namespace RMDataLibrary.Models
{
    public class OrderDetailDBModel
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
