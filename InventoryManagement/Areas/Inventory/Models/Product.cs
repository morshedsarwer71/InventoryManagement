using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double SalesPrice { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public int CategoryID { get; set; }
        public string ProductCode { get; set; }
        public double PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
    }
}