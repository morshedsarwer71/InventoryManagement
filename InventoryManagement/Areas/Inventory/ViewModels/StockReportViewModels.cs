﻿using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class StockReportViewModels
    {
        public IEnumerable<ResponseStockReport> stockReports { get; set; }
    }
}