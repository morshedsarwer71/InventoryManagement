using InventoryManagement.Areas.Global.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Areas.Global.Controllers
{
    public class GlobalDalaController : Controller
    {
        // GET: Global/GlobalDala
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(SystemUser systemUser)
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOut()
        {
            return View();
        }
    }
}