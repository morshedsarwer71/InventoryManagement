﻿using InventoryManagement.Areas.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.ViewModels
{
    public class CategoryViewModels
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}