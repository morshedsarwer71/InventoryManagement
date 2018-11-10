using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Areas.Accounting.Controllers
{
    public class AccountingDataController : Controller
    {
        // GET: Accounting/AccountingData
        public ActionResult Index()
        {
            return View();
        }
    }
}