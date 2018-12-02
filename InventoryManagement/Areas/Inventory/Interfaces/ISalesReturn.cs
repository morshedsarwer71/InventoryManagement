﻿using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface ISalesReturn
    {
        void AddSalesReturnInvoice(SessionInvoice sessionInvoice, int userId, int concernId);
        IEnumerable<ResponseSales> ResponseSales(int concernId, int page, string salesCode);
        IEnumerable<ResponseSales> ResponseSalesReturns(int concernId, string salesCode);
    }
}
