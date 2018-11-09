using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class SalesInvoice
    {
        [Key]
        public int SalesInvoiceID { get; set; }
        public string SalesInvoiceCode { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        public decimal SalesUnitPrice { get; set; }
        public int BuyerID { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
        public System.DateTime SalesDate { get; set; }
        public decimal CashPayment { get; set; }
        public decimal DuePayment { get; set; }
        public decimal Discount { get; set; }
    }
}