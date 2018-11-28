using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return RedirectToAction("Index","InventoryData",new { Area="Inventory"});
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
    }
}