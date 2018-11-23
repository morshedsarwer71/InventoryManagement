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
        public SalesReturnService(DataContext context, IDuePayment payment)
        {
            _context = context;
            _payment = payment;
        }
        public void AddSalesReturnInvoice(SessionInvoice sessionInvoice, int userId, int concernId)
        {
            List<SalesReturnInvoice> salesInvoices = new List<SalesReturnInvoice>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);
            var dateString = DateTime.Now;
            var invoiceCode = DateTime.Now.ToString("mmddfff") + "" + userId + "" + concernId;            
            using (var transaction = _context.Database.BeginTransaction())
            {                
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
                        SalesInvoiceCode = invoiceCode,
                        SRUnitPrice = item.UnitPrice
                    });
                }
                _context.SalesReturnInvoices.AddRange(salesInvoices);
                _context.SaveChanges();
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
    }
}