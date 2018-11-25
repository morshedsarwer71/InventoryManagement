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
        private readonly IPurchaseInvoice _purchase;
        private readonly IPurchaseReturn _purchaseReturn;
        private readonly ISalesReturn _salesReturn;
        private readonly IDuePayment _payment;
        public InventoryDataController(IBuyer buyer, IInventorySetting inventorySetting, ISession session, ISalesInvoice salesInvoice, IPurchaseInvoice purchase, IPurchaseReturn purchaseReturn, ISalesReturn salesReturn, IDuePayment payment)
        {
            _buyer = buyer;
            _inventorySetting = inventorySetting;
            _session = session;
            _salesInvoice = salesInvoice;
            _purchase = purchase;
            _purchaseReturn = purchaseReturn;
            _salesReturn = salesReturn;
            _payment = payment;
        }
        // GET: Inventory/InventoryData
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Buyer()
        {
            return View();
        }
        [HttpGet]
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
        public JsonResult NewBuyers(int page)
        {
            var responseBuyers = _buyer.Buyers(1, page);
            BuyerIndexViewModels buyerIndexViewModels = new BuyerIndexViewModels()
            {
                GetResponseBuyers = responseBuyers
            };
            return Json(buyerIndexViewModels, JsonRequestBehavior.AllowGet);
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
                return Json("cannot added", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteBuyer(int id)
        {
            _buyer.Delete(id, 1);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpdateBuyer(int id)
        {
            return View(_buyer.Buyer(id));
        }
        [HttpPost]
        public ActionResult UpdateBuyer(int id, Buyer buyer)
        {
            _buyer.Update(id, buyer);
            return RedirectToAction(nameof(Buyer));
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
        public JsonResult AddUnit(Unit unit)
        {
            _inventorySetting.AddUnit(unit, 1, 1);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteUnit()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateUnit(int id)
        {            
            return View();
        }
        [HttpPost]
        public ActionResult UpdateUnit(int id,Unit unit)
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
            var category = _inventorySetting.Categories(1);
            CategoryViewModels viewModels = new CategoryViewModels()
            {
                Categories = category
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCategory(Category category)
        {
            _inventorySetting.AddCategory(category, 1, 1);
            return Json("addded",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Product()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products(int page=1)
        {
            var products = _inventorySetting.Products(1,page);
            ProductIndexViewModels viewModels = new ProductIndexViewModels()
            {
                Products=products
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var unit = _inventorySetting.Units(1);
            var category = _inventorySetting.Categories(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Units=unit,
                Categories=category
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            _inventorySetting.AddProduct(product,1,1);
            return Json("addded", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SessionInvoices()
        {
            var sessions = _session.ResponseSessions(1, 1);
            SessionViewModels viewModels = new SessionViewModels()
            {
                ResponseSessions = sessions
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
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
        public JsonResult ClearSession()
        {
            _session.ClearSessionInvoice(1, 1);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClearById(int id)
        {
            _session.Delete(1, 1, id);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProductPrice(int id)
        {
            return Json(_session.ProductPrice(id, 1), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SalesInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesInvoices(int page=1)
        {
            var sales = _salesInvoice.ResponseSales(1, page, "0");
            SalesIndexViewModels viewModels = new SalesIndexViewModels()
            {
                ResponseSales = sales
            };
            return View(viewModels);
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
                Buyers = buyers,
                Suppliers = suppliers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddSalesInvoice(SessionInvoice sessionInvoice)
        {
            _salesInvoice.AddSalesInvoice(sessionInvoice, 1, 1);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SalesReturnInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesReturnInvoices(int page = 1)
        {
            var returns = _salesReturn.ResponseSales(1, page, "0");
            SalesReturnIndexViewModels viewModels = new SalesReturnIndexViewModels()
            {
                ResponseSalesReturn = returns
            };
            return View(viewModels);
        }

        [HttpGet]
        public ActionResult AddSalesReturnInvoice()
        {
            var products = _inventorySetting.Products(1);
            var buyers = _inventorySetting.Buyers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Products = products,
                Buyers = buyers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddSalesReturnInvoice(SessionInvoice sessionInvoice)
        {
            _salesReturn.AddSalesReturnInvoice(sessionInvoice, 1, 1);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PurchaseInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PurchaseInvoices(int page = 1)
        {

            var purchases = _purchase.ResponsePurchases(1, page, "0");
            
            PurchaseIndexViewModels viewModels = new PurchaseIndexViewModels()
            {
                ResponsePurchases=purchases
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddPurchaseInvoice()
        {
            var products = _inventorySetting.Products(1);
            var buyers = _inventorySetting.Buyers(1);
            var suppliers = _inventorySetting.Suppliers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Products = products,
                Buyers = buyers,
                Suppliers = suppliers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddPurchaseInvoice(SessionInvoice sessionInvoice)
        {
            _purchase.AddPurchaseInvoice(sessionInvoice, 1, 1);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PurchaseReturnInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PurchaseReturnInvoices(int page = 1)
        {
            var returns = _purchaseReturn.ResponsePurchases(1, page, "0");
            PurchaseReturnIndexViewModels viewModels = new PurchaseReturnIndexViewModels()
            {
                ResponsePurchaseReturns= returns
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddPurchaseReturnInvoice()
        {
            var products = _inventorySetting.Products(1);
            var suppliers = _inventorySetting.Suppliers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Products = products,
                Suppliers = suppliers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddPurchaseReturnInvoice(SessionInvoice sessionInvoice)
        {
            _purchaseReturn.AddPurchaseInvoice(sessionInvoice, 1, 1);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuyerPayment()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BuyerPayments(int page=1)
        {
            var paymnets = _payment.BuyerDuePayments(1, 1);
            DuePaymentViewModels viewModels = new DuePaymentViewModels()
            {
                ResponseDues= paymnets
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddBuyerPayment()
        {
            var buyers = _inventorySetting.Buyers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Buyers = buyers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddBuyerPayment(SalesDuePayment salesDuePayment)
        {
            _payment.AddBuyerPayment(salesDuePayment, 1, 1);
            return Json("Added",JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SupplierPayment()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SupplierPayments(int page = 1)
        {
            var paymnets = _payment.SupplierDuePayments(1, 1);
            DuePaymentViewModels viewModels = new DuePaymentViewModels()
            {
                ResponseDues = paymnets
            };
            return View(viewModels);
        }
        [HttpGet]
        public ActionResult AddSupplierPayment()
        {
            var suppliers = _inventorySetting.Suppliers(1);
            VendorsViewModels viewModels = new VendorsViewModels()
            {
                Suppliers = suppliers
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddSupplierPayment(PurchaseDuePayment DuePayment)
        {
            _payment.AddSupplierPayment(DuePayment, 1, 1);
            return Json("Added", JsonRequestBehavior.AllowGet);
        }


    }
}