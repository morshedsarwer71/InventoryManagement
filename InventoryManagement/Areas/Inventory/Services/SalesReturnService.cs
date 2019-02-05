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
    public class SalesReturnService : ISalesReturn
    {
        private readonly DataContext _context;
        private readonly IDuePayment _payment;
        private readonly IJournal _journal;
        public SalesReturnService(DataContext context, IDuePayment payment, IJournal journal)
        {
            _context = context;
            _payment = payment;
            _journal = journal;
        }
        public void AddSalesReturnInvoice(SessionInvoice sessionInvoice, int userId, int concernId)
        {
            List<SalesReturnInvoice> salesInvoices = new List<SalesReturnInvoice>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);
            var dateString = DateTime.Now;
            //var invoiceCode = DateTime.Now.ToString("mmddfff");
            using (var transaction = _context.Database.BeginTransaction())
            {
                SalesDuePayment salesDue = new SalesDuePayment();
                salesDue.PaymentDate = dateString;
                salesDue.CreationDate = dateString;
                salesDue.BuyerID = sessionInvoice.BuyerID;
                salesDue.Description = "Sales Return Code : " + " " +sessionInvoice.Code;
                salesDue.Code = sessionInvoice.Code;
                salesDue.IsDelete = 0;
                salesDue.PaymentAmount = sessionInvoice.DuePayment;
                salesDue.ConcernID = concernId;
                salesDue.Creator = userId;
                _context.SalesDuePayments.Add(salesDue);
                _context.SaveChanges();
                foreach (var item in sessionData)
                {
                    salesInvoices.Add(new SalesReturnInvoice()
                    {
                        SRBuyerID = item.BuyerID,
                        SRCashPayment = sessionInvoice.CashPayment,
                        ConcernID = concernId,
                        CreationDate = dateString,
                        Creator = userId,
                        Description = sessionInvoice.Description,
                        SRDiscount = sessionInvoice.Discount,
                        SRDuePayment = item.DuePayment,
                        IsDelete = item.IsDelete,
                        SRProductID = item.ProductID,
                        SRQuantity = item.Quantity,
                        SRDate = item.Date,
                        SRInvoiceCode = sessionInvoice.Code,
                        SRUnitPrice = item.UnitPrice
                    });
                }
                _context.SalesReturnInvoices.AddRange(salesInvoices);
                _context.SaveChanges();
                //Journal

                if (sessionInvoice.DuePayment > 0)
                {
                    
                        //Journal Input-- Due
                        Journal journalCash = new Journal();
                        journalCash.DebitAccountsHeadId = 3;
                        journalCash.CreditAccountsHeadId = 7;
                        journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                        journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                        journalCash.JournalEntryDate = dateString;
                        journalCash.VoucherCode = sessionInvoice.Code;
                        journalCash.Description = "Sales Return";
                        _journal.AddJournal(journalCash, userId, concernId);

                        //Journal Input-- Cash
                        Journal journalDue = new Journal();
                        journalDue.DebitAccountsHeadId = 3;
                        journalDue.CreditAccountsHeadId = 10;
                        journalDue.DebitJournalAmount = sessionInvoice.DuePayment;
                        journalDue.CreditJournalAmount = sessionInvoice.DuePayment;
                        journalDue.JournalEntryDate = dateString;
                        journalDue.VoucherCode = sessionInvoice.Code;
                        journalDue.Description = "Sales Return";
                        _journal.AddJournal(journalDue, userId, concernId);                  
                    

                }
                else
                {
                    Journal journalCash = new Journal();
                    journalCash.DebitAccountsHeadId = 3;
                    journalCash.CreditAccountsHeadId = 7;
                    journalCash.DebitJournalAmount = sessionInvoice.CashPayment;
                    journalCash.CreditJournalAmount = sessionInvoice.CashPayment;
                    journalCash.JournalEntryDate = dateString;
                    journalCash.VoucherCode = sessionInvoice.Code;
                    journalCash.Description = "Sales Return";
                    _journal.AddJournal(journalCash, userId, concernId);
                }

                _context.SessionInvoices.RemoveRange(sessionData);
                _context.SaveChanges();
                transaction.Commit();

            }
        }

        public IEnumerable<ResponseSales> ResponseSales(int concernId, int page, string salesCode)
        {
            List<ResponseSales> responses = new List<ResponseSales>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_SalesReturnIndex @concernId,@PageNumber,@SalesCode";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@PageNumber", page));
                command.Parameters.Add(new SqlParameter("@SalesCode", salesCode));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseSales()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                SalesCode = Convert.ToString(result[1]),
                                SalesDate = Convert.ToDateTime(result[3]),
                                BuyerName = Convert.ToString(result[5]),
                                TotalPrice = Convert.ToDecimal(result[7]),
                                Cash = Convert.ToDecimal(result[8]),
                                Discount = Convert.ToDecimal(result[6]),
                                GrandTotal = Convert.ToDecimal(result[7]),
                                Rows = Convert.ToInt32(result[8]),
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseSales> ResponseSalesReturns(int concernId, string salesCode)
        {
            List<ResponseSales> responses = new List<ResponseSales>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_StockManagement_SalesReturnInvoiceProductDetails @InvoiceCode,@concernID";
                command.Parameters.Add(new SqlParameter("@InvoiceCode", salesCode));
                command.Parameters.Add(new SqlParameter("@concernID", concernId));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseSales()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                SalesCode = Convert.ToString(result[1]),
                                SalesDate = Convert.ToDateTime(result[2]),
                                ProductName = Convert.ToString(result[3]),
                                BuyerName = Convert.ToString(result[4]),
                                Quantity = Convert.ToDecimal(result[5]),
                                SalesPrice = Convert.ToDecimal(result[6]),
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