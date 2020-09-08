using System;
using System.Collections.Generic;
using System.Text;

namespace RMDataLibrary.Models
{
    public class FoodModel
    {
        // Id in database
        public int Id { get; set; }
        
        // Type of food
        public string FoodType { get; set; }

        // Name of food
        public string FoodName { get; set; }

        // Price of food
        public decimal Price { get; set; }

        // Quantity of food in a specific order
        public int Quantity { get; set; }

        // Id  of Order that ordered this food
        public int OrderId { get; set; } 
    }
}
