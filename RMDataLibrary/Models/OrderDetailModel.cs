﻿using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace RMDataLibrary.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int DiningTableId { get; set; }
        public int ServerId { get; set; }      
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
