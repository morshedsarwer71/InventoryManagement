using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        [Required]
        public string BuyerAddress { get; set; }        
        public decimal BuyerBalance { get; set; }        
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public string AlternateMobileNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
    }
}