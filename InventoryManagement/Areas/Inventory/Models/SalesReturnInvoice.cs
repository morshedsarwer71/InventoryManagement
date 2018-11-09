using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class SalesReturnInvoice
    {
        [Key]
        public int SRInvoiceID { get; set; }
        public string SRInvoiceCode { get; set; }
        [Required]
        public int SRProductID { get; set; }
        [Required]
        public decimal SRQuantity { get; set; }
        [Required]
        public decimal SRUnitPrice { get; set; }
        public decimal SRCashPayment { get; set; }
        public decimal SRDuePayment { get; set; }
        public decimal SRDiscount { get; set; }
        public int SRBuyerID { get; set; }
        public DateTime SRDate { get; set; }
        public string SalesInvoiceCode { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
    }
}