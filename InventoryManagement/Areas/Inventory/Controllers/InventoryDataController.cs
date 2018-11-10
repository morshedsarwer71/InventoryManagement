using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Areas.Inventory.Controllers
{
    public class InventoryDataController : Controller
    {
        private readonly IBuyer _buyer;
        public InventoryDataController(IBuyer buyer)
        {
            _buyer = buyer;
        }
        // GET: Inventory/InventoryData
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buyers()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddBuyer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBuyer(Buyer buyer)
        {
            _buyer.Add(buyer);
            return View();
        }
    }
}