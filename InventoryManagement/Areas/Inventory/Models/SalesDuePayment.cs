using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class SalesDuePayment
    {
        [Key]
        public int SalesDuePaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int BuyerID { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}