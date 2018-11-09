using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierAddress { get; set; }
        [Required]
        public decimal SupplierBalance { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public string AlternateMobileNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
    }
}