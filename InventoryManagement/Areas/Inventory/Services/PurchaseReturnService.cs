using InventoryManagement.Areas.Accounting.Interfaces;
using InventoryManagement.Areas.Accounting.Models;
using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Services
{
    public class PurchaseReturnService : IPurchaseReturn
    {
        private readonly DataContext _context;
        private readonly IJournal _journal;
        public PurchaseReturnService(DataContext context, IJournal journal)
        {
            _context = context;
            _journal = journal;
        }
        public void AddPurchaseInvoice(SessionInvoice sessionInvoice, int userId, int concernId)
        {
            List<PurchaseReturnInvoice> purchaseInvoices = new List<PurchaseReturnInvoice>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);
            var dateString = DateTime.Now;
            //var invoiceCode = DateTime.Now.ToString("mmddfff") + "" + userId + "" + concernId;
            using (var transaction = _context.Database.BeginTransaction())
            {
                PurchaseDuePayment purchaseDue = new PurchaseDuePayment();
                purchaseDue.PaymentDate = dateString;
                purchaseDue.CreationDate = dateString;
                purchaseDue.SupplierID = sessionInvoice.BuyerID;
                purchaseDue.Description = "Sales Return Code : " + " " + sessionInvoice.Code;
                purchaseDue.IsDelete = 0;
                purchaseDue.Code = sessionInvoice.Code;
                purchaseDue.PaymentAmount = sessionInvoice.DuePayment;
                purchaseDue.ConcernID = concernId;
                purchaseDue.Creator = userId;
                _context.PurchaseDuePayments.Add(purchaseDue);
                _context.SaveChanges();
                foreach (var item in sessionData)
                {
                    purchaseInvoices.Add(new PurchaseReturnInvoice()
                    {
                        PRSupplierID = sessionInvoice.BuyerID,
                        PRCashPayment = sessionInvoice.CashPayment,
                        ConcernID = concernId,
                        CreationDate = dateString,
                        Creator = userId,
                        Description = sessionInvoice.Description,
                        PRDiscount = sessionInvoice.Discount,
                        IsDelete = item.IsDelete,
                        PRProductID = item.ProductID,
                        PRQuantity = item.Quantity,
                        PRDate = item.Date,
                        PurchaseInvoiceCode = sessionInvoice.Code,
                        PRUnitPrice = item.UnitPrice,
                        PRInvoiceCode = sessionInvoice.Code
                    });
                }
                if (sessionInvoice.DuePayment > 0)
                {

                    Journal journalCash = new Journal();
                    journalCash.DebitAccountsHeadId = 10;
                    journalCash.CreditAccountsHeadId = 4;
                    journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                    journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                    journalCash.JournalEntryDate = dateString;
                    journalCash.VoucherCode = sessionInvoice.Code;
                    journalCash.Description = "Purchase Return";
                    _journal.AddJournal(journalCash, userId, concernId);

                    //Journal Input-- Cash
                    Journal journalDue = new Journal();
                    journalDue.DebitAccountsHeadId = 8;
                    journalDue.CreditAccountsHeadId = 4;
                    journalDue.DebitJournalAmount = sessionInvoice.DuePayment;
                    journalDue.CreditJournalAmount = sessionInvoice.DuePayment;
                    journalDue.JournalEntryDate = dateString;
                    journalDue.VoucherCode = sessionInvoice.Code;
                    journalDue.Description = "Purchase Return";
                    _journal.AddJournal(journalDue, userId, concernId);

                }
                else
                {
                    Journal journalCash = new Journal();
                    journalCash.DebitAccountsHeadId = 10;
                    journalCash.CreditAccountsHeadId = 4;
                    journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                    journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                    journalCash.JournalEntryDate = dateString;
                    journalCash.VoucherCode = sessionInvoice.Code;
                    journalCash.Description = "Purchase Return";
                    _journal.AddJournal(journalCash, userId, concernId);
                }
                _context.PurchaseReturnInvoices.AddRange(purchaseInvoices);
                _context.SaveChanges();
                _context.SessionInvoices.RemoveRange(sessionData);
                _context.SaveChanges();
                transaction.Commit();

            }
        }

        public IEnumerable<ResponsePurchaseReturn> ResponsePurchases(int concernId, int page, string purchaseCode)
        {
            List<ResponsePurchaseReturn> responses = new List<ResponsePurchaseReturn>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_PurchaseReturnIndex @concernId,@PageNumber,@ReturnCode";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@PageNumber", page));
                command.Parameters.Add(new SqlParameter("@ReturnCode", purchaseCode));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponsePurchaseReturn()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                PurchaseReturnCode = Convert.ToString(result[1]),
                                PurchaseReturnDate = Convert.ToDateTime(result[2]),
                                SupplierName = Convert.ToString(result[4]),
                                TotalPrice = Convert.ToDecimal(result[6]),
                                Cash = Convert.ToDecimal(result[7]),
                                Discount = Convert.ToDecimal(result[8]),
                                Due = Convert.ToDecimal(result[9]),
                                Rows = Convert.ToInt32(result[10]),
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponsePurchase> ResponsePurchasesByCode(int concernId, string purchaseCode)
        {
            List<ResponsePurchase> responses = new List<ResponsePurchase>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_StockManagement_PurchaseReturnInvoiceProductDetails @InvoiceCode,@concernID";
                command.Parameters.Add(new SqlParameter("@InvoiceCode", purchaseCode));
                command.Parameters.Add(new SqlParameter("@concernID", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponsePurchase()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                PurchaseCode = Convert.ToString(result[1]),
                                PurchaseDate = Convert.ToDateTime(result[2]),
                                ProductName = Convert.ToString(result[3]),
                                SupplierName = Convert.ToString(result[4]),
                                UnitPrice = Convert.ToDecimal(result[5]),
                                Quantity = Convert.ToDecimal(result[6]),
                                TotalPrice = Convert.ToDecimal(result[7]),
                                Cash = Convert.ToDecimal(result[8]),
                                Discount = Convert.ToDecimal(result[9]),
                                GrandTotal = Convert.ToDecimal(result[10]),
                                Saler = Convert.ToString(result[11]),

                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }
    }
}