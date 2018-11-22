using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
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
            List<SalesInvoiceService> salesInvoices = new List<SalesInvoiceService>();
            var sessionData = _context.SessionInvoices.Where(m => m.ConcernID == concernId && m.UserID == userId);            
            using (var transaction = _context.Database.BeginTransaction())
            {
                var dateString = DateTime.Now.ToString("mmddfff");
                var invoiceCode = dateString + "" + userId + "" + concernId;
                foreach (var item in sessionData)
                {
                    _context.SessionInvoices.Remove(item);
                    
                }
                _context.SaveChanges();
                transaction.Commit();

            }
        }
    }
}