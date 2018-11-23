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

        public Buyer Buyer(int id)
        {
            return _context.Buyers.FirstOrDefault(m=>m.BuyerID==id);
        }

        public IEnumerable<ResponseBuyer> Buyers(int concernId,int page)
        {
            List<ResponseBuyer> ResponseBuyers = new List<ResponseBuyer>();
            using (var command= _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_BuyerIndex @ConcernID,@Page";
                command.Parameters.Add(new SqlParameter("@ConcernID",concernId));
                command.Parameters.Add(new SqlParameter("@Page",page));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            ResponseBuyers.Add(new ResponseBuyer {
                                Serial=Convert.ToInt32(result[0]),
                                BuyerID= Convert.ToInt32(result[1]),
                                BuyerName= Convert.ToString(result[2]),
                                MobileNumber= Convert.ToString(result[3]),
                                AlternateMobileNumber= Convert.ToString(result[4]),
                                BuyerAddress= Convert.ToString(result[5]),
                                NumberOfRow= Convert.ToInt32(result[6]),
                                BuyerBalance= Convert.ToDecimal(result[7]),
                                Description= Convert.ToString(result[8]),
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return ResponseBuyers;
        }

        public void Delete(int id, int concernId)
        {
            var buyer = _context.Buyers.FirstOrDefault(x=>x.BuyerID==id);
            _context.Buyers.Remove(buyer);
            _context.SaveChanges();
        }

        public void Update(int id, Buyer buyer)
        {
            var ubuyer = Buyer(id);
            ubuyer.BuyerName = buyer.BuyerName;
            ubuyer.AlternateMobileNumber = buyer.AlternateMobileNumber;
            ubuyer.BuyerAddress = buyer.BuyerAddress;
            ubuyer.BuyerBalance = buyer.BuyerBalance;
            ubuyer.Description = buyer.Description;
            _context.SaveChanges();
        }
    }
}