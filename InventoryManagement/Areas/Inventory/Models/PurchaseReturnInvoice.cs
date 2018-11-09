using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Models
{
    public class PurchaseReturnInvoice
    {
        [Key]
        public int PRInvoiceID { get; set; }
        public string PRInvoiceCode { get; set; }
        public string PurchaseInvoiceCode { get; set; }
        public int PRProductID { get; set; }
        public decimal PRQuantity { get; set; }
        public decimal PRUnitPrice { get; set; }
        public decimal SalesUnitPrice { get; set; }
        public int PRSupplierID { get; set; }
        public System.DateTime PRDate { get; set; }
        public decimal PRCashPayment { get; set; }
        public decimal PRDuePayment { get; set; }
        public decimal PRDiscount { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int Creator { get; set; }
        public int IsDelete { get; set; }
    }
}