﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Accounting.ResponseModels
{
    public class BalanceSheet
    {
        public string Particulars { get; set; }
        public decimal ValueOne { get; set; }
        public decimal ValueTwo { get; set; }
        public decimal ValueThree { get; set; }
    }
}