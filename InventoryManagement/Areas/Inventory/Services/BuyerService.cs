using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Services
{
    public class BuyerService : IBuyer
    {
        private readonly DataContext _context;
        public BuyerService(DataContext context)
        {
            _context = context;
        }
        public void Add(Buyer buyer)
        {
            buyer.ConcernID = 1;
            buyer.CreationDate = DateTime.Now;
            buyer.Creator = 1;
            _context.Buyers.Add(buyer);
            _context.SaveChanges();
        }
    }
}