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
        private readonly IReport _report;
        private readonly ISupplier  _supplier;
        public InventoryDataController(IBuyer buyer, IInventorySetting inventorySetting, ISession session, ISalesInvoice salesInvoice, IPurchaseInvoice purchase, IPurchaseReturn purchaseReturn, ISalesReturn salesReturn, IDuePayment payment, IReport report, ISupplier supplier)
        {
            _buyer = buyer;
            _inventorySetting = inventorySetting;
            _session = session;
            _salesInvoice = salesInvoice;
            _purchase = purchase;
            _purchaseReturn = purchaseReturn;
            _salesReturn = salesReturn;
            _payment = payment;
            _report = report;
            _supplier = supplier;
        }
        // GET: Inventory/InventoryData
        public ActionResult Index(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stocks = _report.ResponseStockReports(concernId, page);
                StockReportViewModels viewModels = new StockReportViewModels()
                {
                    stockReports = stocks
                };
                return View(viewModels);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Buyer()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Buyers(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var responseBuyers = _buyer.Buyers(concernId, page);
                BuyerIndexViewModels buyerIndexViewModels = new BuyerIndexViewModels()
                {
                    GetResponseBuyers = responseBuyers
                };
                return View(buyerIndexViewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public JsonResult NewBuyers(int page)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);

            var responseBuyers = _buyer.Buyers(concernId, page);
            BuyerIndexViewModels buyerIndexViewModels = new BuyerIndexViewModels()
            {
                GetResponseBuyers = responseBuyers
            };
            return Json(buyerIndexViewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddBuyer()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult AddBuyer(Buyer buyer)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (ModelState.IsValid)
            {
                _buyer.Add(buyer,concernId,userId);
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
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _buyer.Delete(id,concernId);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpdateBuyer(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View(_buyer.Buyer(id));
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpPost]
        public ActionResult UpdateBuyer(int id, Buyer buyer)
        {
            _buyer.Update(id, buyer);
            return RedirectToAction(nameof(Buyer));
        }
        [HttpGet]
        public ActionResult Supplier()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Suppliers(int page=1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var suppliers = _supplier.ResponseSuppliers(concernId, page);
                SupplierIndexViewModels viewModels = new SupplierIndexViewModels()
                {
                    ResponseSuppliers = suppliers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddSupplier()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {               
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddSupplier(Supplier supplier)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _supplier.AddSupplier(supplier,concernId,userId);
            return Json("added successfully",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Unit()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult Units()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var units = _inventorySetting.Units(concernId);
                UnitIndexViewModels viewModels = new UnitIndexViewModels()
                {
                    Units = units
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult AddUnit()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpPost]
        public JsonResult AddUnit(Unit unit)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _inventorySetting.AddUnit(unit,userId,concernId);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteUnit()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult UpdateUnit(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpPost]
        public ActionResult UpdateUnit(int id, Unit unit)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Category()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult Categories()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var category = _inventorySetting.Categories(concernId);
                CategoryViewModels viewModels = new CategoryViewModels()
                {
                    Categories = category
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpPost]
        public JsonResult AddCategory(Category category)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _inventorySetting.AddCategory(category,userId,concernId);
            return Json("addded", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Product()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });            
        }
        [HttpGet]
        public ActionResult Products(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var products = _inventorySetting.Products(concernId, page);
                ProductIndexViewModels viewModels = new ProductIndexViewModels()
                {
                    Products = products
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var unit = _inventorySetting.Units(1);
                var category = _inventorySetting.Categories(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Units = unit,
                    Categories = category
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _inventorySetting.AddProduct(product,userId,concernId);
            return Json("addded", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SessionInvoices()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var sessions = _session.ResponseSessions(concernId,userId);
            SessionViewModels viewModels = new SessionViewModels()
            {
                ResponseSessions = sessions
            };
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddSessionInvoice(SessionInvoice sessionInvoice)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _session.AddSessionInvoice(userId,concernId, sessionInvoice);
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
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _session.ClearSessionInvoice(userId,concernId);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClearById(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _session.Delete(userId,concernId, id);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProductPrice(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            return Json(_session.ProductPrice(id,concernId), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SalesInvoice()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesInvoices(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var sales = _salesInvoice.ResponseSales(concernId, page, "0");
                SalesIndexViewModels viewModels = new SalesIndexViewModels()
                {
                    ResponseSales = sales
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }

        [HttpGet]
        public ActionResult AddSalesInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var products = _inventorySetting.Products(concernId);
                var buyers = _inventorySetting.Buyers(concernId);
                var suppliers = _inventorySetting.Suppliers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Products = products,
                    Buyers = buyers,
                    Suppliers = suppliers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddSalesInvoice(SessionInvoice sessionInvoice)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _salesInvoice.AddSalesInvoice(sessionInvoice,userId,concernId);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SalesInvoiceByCode(string code)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var InvoiceDetails = _salesInvoice.SalesInvoiceByCode(code, concernId);
                SalesIndexViewModels viewModels = new SalesIndexViewModels()
                {
                    ResponseSales=InvoiceDetails
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult SalesReturnInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });           
        }
        [HttpGet]
        public ActionResult SalesReturnInvoices(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var returns = _salesReturn.ResponseSales(concernId, page, "0");
                SalesReturnIndexViewModels viewModels = new SalesReturnIndexViewModels()
                {
                    ResponseSalesReturn = returns
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }

        [HttpGet]
        public ActionResult AddSalesReturnInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var products = _inventorySetting.Products(concernId);
                var buyers = _inventorySetting.Buyers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Products = products,
                    Buyers = buyers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddSalesReturnInvoice(SessionInvoice sessionInvoice)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _salesReturn.AddSalesReturnInvoice(sessionInvoice,userId,concernId);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PurchaseInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {               
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult PurchaseInvoices(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var purchases = _purchase.ResponsePurchases(concernId, page, "0");

                PurchaseIndexViewModels viewModels = new PurchaseIndexViewModels()
                {
                    ResponsePurchases = purchases
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddPurchaseInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var products = _inventorySetting.Products(concernId);
                var buyers = _inventorySetting.Buyers(concernId);
                var suppliers = _inventorySetting.Suppliers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Products = products,
                    Buyers = buyers,
                    Suppliers = suppliers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddPurchaseInvoice(SessionInvoice sessionInvoice)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _purchase.AddPurchaseInvoice(sessionInvoice,userId,concernId);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PurchaseReturnInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {               
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult PurchaseReturnInvoices(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var returns = _purchaseReturn.ResponsePurchases(concernId, page, "0");
                PurchaseReturnIndexViewModels viewModels = new PurchaseReturnIndexViewModels()
                {
                    ResponsePurchaseReturns = returns
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddPurchaseReturnInvoice()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {

                var products = _inventorySetting.Products(concernId);
                var suppliers = _inventorySetting.Suppliers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Products = products,
                    Suppliers = suppliers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddPurchaseReturnInvoice(SessionInvoice sessionInvoice)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _purchaseReturn.AddPurchaseInvoice(sessionInvoice,userId,concernId);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuyerPayment()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult BuyerPayments(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var paymnets = _payment.BuyerDuePayments(concernId,page);
                DuePaymentViewModels viewModels = new DuePaymentViewModels()
                {
                    ResponseDues = paymnets
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddBuyerPayment()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var buyers = _inventorySetting.Buyers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Buyers = buyers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddBuyerPayment(SalesDuePayment salesDuePayment)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _payment.AddBuyerPayment(salesDuePayment,concernId,userId);
            return Json("Added", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SupplierPayment()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {               
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult SupplierPayments(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var paymnets = _payment.SupplierDuePayments(concernId, page);
                DuePaymentViewModels viewModels = new DuePaymentViewModels()
                {
                    ResponseDues = paymnets
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult AddSupplierPayment()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var suppliers = _inventorySetting.Suppliers(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    Suppliers = suppliers
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpPost]
        public JsonResult AddSupplierPayment(PurchaseDuePayment DuePayment)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _payment.AddSupplierPayment(DuePayment,concernId,userId);
            return Json("Added", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ExpenseName()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {                
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult ExpenseNames()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var expenseNames = _inventorySetting.ExpenseNames(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    ExpenseNames=expenseNames
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddExpenseName()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var expense = _inventorySetting.ExpenseTypes(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    ExpenseTypes=expense
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddExpenseName(ExpenseName expenseName)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _inventorySetting.AddExpenseName(expenseName, concernId, userId);
            return Json("added successfully",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Expense()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult Expenses(int page=1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var expense = _inventorySetting.ResponseExpenses(concernId,page);
                ExpenseIndexViewModels viewModels = new ExpenseIndexViewModels()
                {
                    ResponseExpenses=expense
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpGet]
        public ActionResult AddExpense()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var expenseNames = _inventorySetting.ExpenseNames(concernId);
                VendorsViewModels viewModels = new VendorsViewModels()
                {
                    ExpenseNames = expenseNames
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
        }
        [HttpPost]
        public JsonResult AddExpense(Expense expense)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            _inventorySetting.AddExpense(expense, concernId, userId);
            return Json("Added successfully",JsonRequestBehavior.AllowGet);
        }

        // REPORTING SECTION

        [HttpGet]
        public ActionResult StockReport(int page = 1)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var stocks = _report.ResponseStockReports(concernId, page);
                StockReportViewModels viewModels = new StockReportViewModels()
                {
                    stockReports = stocks
                };
                return View(viewModels);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });
            
        }
        [HttpGet]
        public ActionResult BuyerDues()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var payments = _report.ResponseBuyerDuesSummaries(concernId);
                ReportDuePayment duePayment = new ReportDuePayment()
                {
                    ResponseDues= payments
                };
                return View(duePayment);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }
        [HttpGet]
        public ActionResult SupplierDues()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                var payments = _report.ResponseSupplierDuesSummaries(concernId);
                ReportDuePayment duePayment = new ReportDuePayment()
                {
                    ResponseDues = payments
                };
                return View(duePayment);
            }
            return RedirectToAction("Login", "GlobalData", new { Area = "Global" });

        }

    }
}