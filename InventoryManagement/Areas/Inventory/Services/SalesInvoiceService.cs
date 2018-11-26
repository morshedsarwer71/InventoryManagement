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
    public class SalesInvoiceService : ISalesInvoice
    {
        private readonly DataContext _context;
        public SalesInvoiceService(DataContext context)
        {
            _context = context;
        }
        public void AddSalesInvoice(SessionInvoice sessionInvoice, int userId, int concernId)
        {
            List<SalesInvoice> salesInvoices = new List<SalesInvoice>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);
            var dateString = DateTime.Now;
            using (var transaction = _context.Database.BeginTransaction())
            {
                foreach (var item in sessionData)
                {
                    salesInvoices.Add(new SalesInvoice() {
                        BuyerID = item.BuyerID,
                        CashPayment = sessionInvoice.CashPayment,
                        ConcernID = concernId,
                        CreationDate = dateString,
                        Creator = userId,
                        Description = sessionInvoice.Description,
                        Discount = sessionInvoice.Discount,
                        DuePayment = item.DuePayment,
                        IsDelete=item.IsDelete,
                        ProductID=item.ProductID,
                        Quantity=item.Quantity,
                        SalesDate=item.Date,
                        SalesInvoiceCode= sessionInvoice.Code,
                        SalesUnitPrice=item.UnitPrice                        
                    });
                }
                _context.SalesInvoices.AddRange(salesInvoices);             
                _context.SaveChanges();
                _context.SessionInvoices.RemoveRange(sessionData);
                _context.SaveChanges();
                transaction.Commit();

            }
        }

        public IEnumerable<ResponseSales> ResponseSales(int concernId, int page, string salesCode)
        {
            List<ResponseSales> responses = new List<ResponseSales>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_SalesIndex @concernId,@PageNumber,@SalesCode";
                command.Parameters.Add(new SqlParameter("@concernId",concernId));
                command.Parameters.Add(new SqlParameter("@PageNumber", page));
                command.Parameters.Add(new SqlParameter("@SalesCode", salesCode));
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
                                SalesDate=Convert.ToDateTime(result[2]),
                                BuyerName=Convert.ToString(result[3]),
                                TotalPrice=Convert.ToDecimal(result[4]),
                                Cash=Convert.ToDecimal(result[5]),
                                Discount=Convert.ToDecimal(result[6]),
                                GrandTotal=Convert.ToDecimal(result[7]),
                                Rows=Convert.ToInt32(result[8]),
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