using InventoryManagement.Areas.Accounting.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.ViewModels
{
    public class BalanceSheetViewModels
    {
        public IEnumerable<BalanceSheet> BalanceSheets { get; set; }
    }
}