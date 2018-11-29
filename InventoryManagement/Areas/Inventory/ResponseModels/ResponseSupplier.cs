using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseSupplier
    {
        public int Serial { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public decimal SupplierBalance { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string MobileNumber { get; set; }
        public int NumberOfRow { get; set; }
    }
}