using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ViewModels;
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
        public ActionResult Buyer()
        {
            return View();
        }
        public ActionResult Buyers(int page=1)
        {
            var responseBuyers = _buyer.Buyers(1,page);
            BuyerIndexViewModels buyerIndexViewModels = new BuyerIndexViewModels()
            {
                GetResponseBuyers= responseBuyers
            };
            return View(buyerIndexViewModels);
        }
        [HttpGet]
        public ActionResult AddBuyer()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult AddBuyer(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _buyer.Add(buyer);
                return Json("Added successfully", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("field required", JsonRequestBehavior.AllowGet);
            }
        }
    }
}