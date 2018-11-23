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
        public DuePaymentService(DataContext context)
        {
            _context = context;
        }
        public void AddBuyerPayment(SalesDuePayment salesDuePayment, int concernId, int userId)
        {
            salesDuePayment.ConcernID = concernId;
            salesDuePayment.Creator = userId;
            salesDuePayment.CreationDate = DateTime.Now;
            _context.SalesDuePayments.Add(salesDuePayment);
            _context.SaveChanges();
        }

        public void AddSupplierPayment(PurchaseDuePayment purchaseDuePayment, int concernId, int userId)
        {
            purchaseDuePayment.CreationDate = DateTime.Now;
            purchaseDuePayment.Creator = userId;
            purchaseDuePayment.ConcernID = concernId;
            _context.PurchaseDuePayments.Add(purchaseDuePayment);
            _context.SaveChanges();
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
                using (var result=command.ExecuteReader())
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