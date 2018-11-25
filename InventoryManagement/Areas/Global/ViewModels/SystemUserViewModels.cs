using InventoryManagement.Areas.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Global.ViewModels
{
    public class SystemUserViewModels
    {
        public IEnumerable<SystemUser> SystemUsers { get; set; }
    }
}