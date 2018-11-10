using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Areas.Accounting.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting/Accounting
        public ActionResult Index()
        {
            return View();
        }
    }
}