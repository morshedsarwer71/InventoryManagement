using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class PurchaseDuePayment
    {
        [Key]
        public int PurchaseDuePaymentID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public int SupplierID { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}