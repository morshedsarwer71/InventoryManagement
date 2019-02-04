using InventoryManagement.Areas.Accounting.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.ViewModels
{
    public class IncomeStatementViewModels
    {
        public IEnumerable<IncomeStatement> IncomeStatements { get; set; }
    }
}