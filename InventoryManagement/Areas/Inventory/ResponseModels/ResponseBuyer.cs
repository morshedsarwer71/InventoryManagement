using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ResponseModels
{
    public class ResponseBuyer
    {
        public int Serial { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public decimal BuyerBalance { get; set; }
        public int ConcernID { get; set; }
        public string Description { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string MobileNumber { get; set; }
        public int NumberOfRow { get; set; }
    }
}