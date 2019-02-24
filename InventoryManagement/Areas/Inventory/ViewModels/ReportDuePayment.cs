using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class ReportDuePayment
    {
        public IEnumerable<ResponseDuesSummary> ResponseDues { get; set; }
        public IEnumerable<ResponsePaymentReport> PaymentReport { get; set; }
        public IEnumerable<Buyer> Buyer { get; set; }
        public IEnumerable<Supplier> Supplier { get; set; }
    }
}