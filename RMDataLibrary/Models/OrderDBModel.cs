using System;
using System.Collections.Generic;
using System.Text;

namespace RMDataLibrary.Models
{
    public class OrderDBModel
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public int DiningTableId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
