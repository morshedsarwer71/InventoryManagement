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
    public class PurchaseInvoiceService : IPurchaseInvoice
    {
        private readonly DataContext _context;
        private readonly IJournal _journal;
        public PurchaseInvoiceService(DataContext context, IJournal journal)
        {
            _context = context;
            _journal = journal;
        }
        public void AddPurchaseInvoice(SessionInvoice sessionInvoice, int userId, int concernId)
        {
            List<PurchaseInvoice> purchaseInvoices = new List<PurchaseInvoice>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);
            var dateString = DateTime.Now;
            //var invoiceCode = DateTime.Now.ToString("mmddfff") + "" + userId + "" + concernId;
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var item in sessionData)
                {
                    purchaseInvoices.Add(new PurchaseInvoice()
                    {
                        SupplierID = item.BuyerID,
                        CashPayment = sessionInvoice.CashPayment,
                        ConcernID = concernId,
                        CreationDate = dateString,
                        Creator = userId,
                        Description = sessionInvoice.Description,
                        Discount = sessionInvoice.Discount,
                        DuePayment = item.DuePayment,
                        IsDelete = item.IsDelete,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        PurchaseDate = item.Date,
                        PurchaseInvoiceCode = sessionInvoice.Code,
                        PurchaseUnitPrice = item.UnitPrice
                    });
                }
                //Journal 
                if (sessionInvoice.DuePayment > 0)
                {
                    //Journal Input-- Cash
                    Journal journalCash = new Journal();
                    journalCash.DebitAccountsHeadId = 2;
                    journalCash.CreditAccountsHeadId = 10;
                    journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                    journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                    journalCash.JournalEntryDate = dateString;
                    journalCash.VoucherCode = sessionInvoice.Code;
                    journalCash.Description = "Purchase";
                    _journal.AddJournal(journalCash, userId, concernId);

                    //Journal Input-- Due
                    Journal journalDue = new Journal();
                    journalDue.DebitAccountsHeadId = 2;
                    journalDue.CreditAccountsHeadId = 8;
                    journalDue.DebitJournalAmount = sessionInvoice.DuePayment;
                    journalDue.CreditJournalAmount = sessionInvoice.DuePayment;
                    journalDue.JournalEntryDate = dateString;
                    journalDue.VoucherCode = sessionInvoice.Code;
                    journalDue.Description = "Purchase";
                    _journal.AddJournal(journalDue, userId, concernId);

                }
                else
                {

                    //Journal Input-- Cash
                    Journal journalCash = new Journal();
                    journalCash.DebitAccountsHeadId = 2;
                    journalCash.CreditAccountsHeadId = 10;
                    journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                    journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                    journalCash.JournalEntryDate = dateString;
                    journalCash.VoucherCode = sessionInvoice.Code;
                    journalCash.Description = "Purchase";
                    _journal.AddJournal(journalCash, userId, concernId);
                }
                _context.PurchaseInvoices.AddRange(purchaseInvoices);
                _context.SaveChanges();
                _context.SessionInvoices.RemoveRange(sessionData);
                _context.SaveChanges();
                transaction.Commit();

            }
        }

        public IEnumerable<ResponsePurchase> ResponsePurchases(int concernId, int page, string purchaseCode)
        {
            List<ResponsePurchase> responses = new List<ResponsePurchase>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_PurchaseIndex @concernId,@PageNumber,@PurchaseInvoiceCode";
                command.Parameters.Add(new SqlParameter("@concernId",concernId));
                command.Parameters.Add(new SqlParameter("@PageNumber", page));
                command.Parameters.Add(new SqlParameter("@PurchaseInvoiceCode", purchaseCode));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponsePurchase()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                PurchaseDate = Convert.ToDateTime(result[1]),
                                PurchaseCode = Convert.ToString(result[2]),
                                SupplierName = Convert.ToString(result[3]),
                                TotalPrice = Convert.ToDecimal(result[4]),
                                Cash = Convert.ToDecimal(result[5]),
                                Discount = Convert.ToDecimal(result[6]),
                                Due = Convert.ToDecimal(result[7]),
                                Rows = Convert.ToInt32(result[8]),
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
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_StockManagement_PurchaseInvoiceProductDetails @InvoiceCode,@concernID";
                command.Parameters.Add(new SqlParameter("@InvoiceCode",purchaseCode));
                command.Parameters.Add(new SqlParameter("@concernID", concernId));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
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