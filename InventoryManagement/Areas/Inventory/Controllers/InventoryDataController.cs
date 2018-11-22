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
        private readonly IInventorySetting _inventorySetting;
        private readonly ISession _session;
        private readonly ISalesInvoice _salesInvoice;
        public InventoryDataController(IBuyer buyer, IInventorySetting inventorySetting, ISession session, ISalesInvoice salesInvoice)
        {
            _buyer = buyer;
            _inventorySetting = inventorySetting;
            _session = session;
            _salesInvoice = salesInvoice;
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
        public ActionResult Buyers(int page = 1)
        {
            var responseBuyers = _buyer.Buyers(1, page);
            BuyerIndexViewModels buyerIndexViewModels = new BuyerIndexViewModels()
            {
                GetResponseBuyers = responseBuyers
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
        [HttpPost]
        public JsonResult DeleteBuyer(int id)
        {
            _buyer.Delete(id, 1);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Unit()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Units()
        {
            var units = _inventorySetting.Units(1);
            UnitIndexViewModels viewModels = new UnitIndexViewModels()
            {
                Units = units
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddUnit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUnit(Unit unit)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Categories()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Product()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddSessionInvoice(SessionInvoice sessionInvoice)
        {
            _session.AddSessionInvoice(1, 1, sessionInvoice);
            var sessions = _session.ResponseSessions(1, 1);
            SessionViewModels viewModels = new SessionViewModels()
            {
                ResponseSessions = sessions
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ClearSession()
        {
            _session.ClearSessionInvoice(1,1);
            return View();
        }
        [HttpPost]
        public ActionResult ClearById(int id)
        {
            _session.Delete(1, 1, id);
            return View();
        }
        [HttpGet]
        public ActionResult SalesInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesInvoices()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AddSalesInvoice()
        {
            var products = _inventorySetting.Products(1);
            var buyers = _inventorySetting.Buyers(1);
            var suppliers = _inventorySetting.Suppliers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Products = products,
                Buyers=buyers,
                Suppliers=suppliers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddSalesInvoice(SessionInvoice sessionInvoice)
        {
            _salesInvoice.AddSalesInvoice(sessionInvoice, 1, 1);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        
    }
}