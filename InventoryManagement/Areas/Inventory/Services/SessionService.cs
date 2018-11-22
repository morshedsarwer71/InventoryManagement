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
    public class SessionService : ISession
    {
        private readonly DataContext _context;
        public SessionService(DataContext context)
        {
            _context = context;
        }
        public void AddSessionInvoice(int userId, int concernId, SessionInvoice sessionInvoice)
        {
            sessionInvoice.CreationDate = DateTime.Now;
            sessionInvoice.UserID = userId;
            sessionInvoice.ConcernID = concernId;
            _context.SessionInvoices.Add(sessionInvoice);
            _context.SaveChanges();
        }

        public void ClearSessionInvoice(int userId, int ConcernId)
        {
            var session = _context.SessionInvoices.Where(m=>m.UserID==userId && m.ConcernID==ConcernId);
            foreach (var item in session)
            {
                _context.SessionInvoices.Remove(item);                
            }
            _context.SaveChanges();
        }

        public void Delete(int userId, int concernId, int sessionId)
        {
            var session = _context.SessionInvoices.FirstOrDefault(m => m.UserID == userId && m.ConcernID == concernId && m.SessionInvoiceID==sessionId);
            _context.SessionInvoices.Remove(session);
            _context.SaveChanges();
        }

        public IEnumerable<ResponseSession> ResponseSessions(int concernId, int userId)
        {
            List<ResponseSession> responses = new List<ResponseSession>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_Session @concernId,@userId";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@userId", userId));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseSession()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                SessionInvoiceId = Convert.ToInt32(result[1]),
                                ProductName = Convert.ToString(result[2]),
                                Quantity = Convert.ToDecimal(result[3]),
                                Price = Convert.ToDecimal(result[4]),
                                TotalPrice = Convert.ToDecimal(result[5]),
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