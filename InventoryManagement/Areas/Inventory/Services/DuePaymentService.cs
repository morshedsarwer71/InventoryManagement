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
    public class DuePaymentService : IDuePayment
    {
        private readonly DataContext _context;
        private readonly IJournal _journal;
        public DuePaymentService(DataContext context, IJournal journal)
        {
            _context = context;
            _journal = journal;
        }
        public void AddBuyerPayment(SalesDuePayment salesDuePayment, int concernId, int userId)
        {
            var today = DateTime.Now;
            var date = DateTime.Now.ToString("mmddfff");
            var code = "4" + date + "5";
            using (var transaction = _context.Database.BeginTransaction())
            {
                salesDuePayment.ConcernID = concernId;
                salesDuePayment.Creator = userId;
                salesDuePayment.CreationDate = today;
                salesDuePayment.Code = code;
                _context.SalesDuePayments.Add(salesDuePayment);
                _context.SaveChanges();

                Journal journalCash = new Journal();
                journalCash.DebitAccountsHeadId = 10;
                journalCash.CreditAccountsHeadId = 7;
                journalCash.DebitJournalAmount = salesDuePayment.PaymentAmount;
                journalCash.CreditJournalAmount = salesDuePayment.PaymentAmount;
                journalCash.JournalEntryDate = today;
                journalCash.VoucherCode = code;
                journalCash.Description = "Client Payment";
                _journal.AddJournal(journalCash, userId, concernId);

                transaction.Commit();
            }
        }
        public void AddSupplierPayment(PurchaseDuePayment purchaseDuePayment, int concernId, int userId)
        {
            var today = DateTime.Now;
            var date = DateTime.Now.ToString("mmddfff");
            var code = "4" + date + "5";
            using (var transaction = _context.Database.BeginTransaction())
            {
                purchaseDuePayment.CreationDate = DateTime.Now;
                purchaseDuePayment.Creator = userId;
                purchaseDuePayment.ConcernID = concernId;
                purchaseDuePayment.Code = code;
                _context.PurchaseDuePayments.Add(purchaseDuePayment);
                _context.SaveChanges();

                Journal journalCash = new Journal();
                journalCash.DebitAccountsHeadId = 8;
                journalCash.CreditAccountsHeadId = 10;
                journalCash.DebitJournalAmount = purchaseDuePayment.PaymentAmount;
                journalCash.CreditJournalAmount = purchaseDuePayment.PaymentAmount;
                journalCash.JournalEntryDate = today;
                journalCash.VoucherCode = code;
                journalCash.Description = "Supplier Payment";
                _journal.AddJournal(journalCash, userId, concernId);

                transaction.Commit();
            }

        }

        public IEnumerable<ResponseDuePayment> BuyerDuePayments(int concernId, int page)
        {
            List<ResponseDuePayment> responses = new List<ResponseDuePayment>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventorymanagement_SalesDuePaymentIndex @ConcernId,@Page";
                command.Parameters.Add(new SqlParameter("@ConcernId", concernId));
                command.Parameters.Add(new SqlParameter("@Page", page));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseDuePayment()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                PaymentId = Convert.ToInt32(result[1]),
                                PaymentDate = Convert.ToDateTime(result[2]),
                                Name = Convert.ToString(result[3]),
                                PayeeId = Convert.ToInt32(result[4]),
                                Amount = Convert.ToDecimal(result[5]),
                                Description = Convert.ToString(result[6]),
                                Rows = Convert.ToInt32(result[7]),
                            });
                        }
                    }
                }
            }
            return responses;
        }

        public IEnumerable<ResponseDuePayment> SupplierDuePayments(int concernId, int page)
        {
            List<ResponseDuePayment> responses = new List<ResponseDuePayment>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventorymanagement_PurchaseDuePaymentIndex @ConcernId,@Page";
                command.Parameters.Add(new SqlParameter("@ConcernId", concernId));
                command.Parameters.Add(new SqlParameter("@Page", page));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseDuePayment()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                PaymentId = Convert.ToInt32(result[1]),
                                PaymentDate = Convert.ToDateTime(result[2]),
                                Name = Convert.ToString(result[3]),
                                PayeeId = Convert.ToInt32(result[4]),
                                Amount = Convert.ToDecimal(result[5]),
                                Description = Convert.ToString(result[6]),
                                Rows = Convert.ToInt32(result[7]),
                            });
                        }
                    }
                }
            }
            return responses;
        }
    }
}