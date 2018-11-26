using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class SessionInvoice
    {
        [Key]
        public int SessionInvoiceID { get; set; }
        [NotMapped]
        public string Code { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CashPayment { get; set; }
        public decimal DuePayment { get; set; }
        public decimal Discount { get; set; }
        public int BuyerID { get; set; }
        public DateTime Date { get; set; }
        public int ConcernID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
    }
}