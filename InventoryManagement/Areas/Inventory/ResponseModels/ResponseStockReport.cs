using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseStockReport
    {
        public int Serial { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Input { get; set; }
        public decimal Output { get; set; }
        public decimal InStock { get; set; }
        public int Rows { get; set; }    }
}