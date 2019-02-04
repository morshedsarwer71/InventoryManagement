using InventoryManagement.Areas.Accounting.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.ViewModels
{
    public class TrailaBalanceViewModels
    {
        public IEnumerable<TrialBalance> TrialBalances { get; set; }
    }
}