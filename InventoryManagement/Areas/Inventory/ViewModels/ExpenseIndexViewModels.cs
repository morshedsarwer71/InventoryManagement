﻿using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class ExpenseIndexViewModels
    {
        public IEnumerable<ResponseExpenses> ResponseExpenses { get; set; }
    }
}