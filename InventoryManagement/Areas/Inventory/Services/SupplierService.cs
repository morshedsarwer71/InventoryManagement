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
    public class SupplierService : ISupplier
    {
        private readonly DataContext _context;
        public SupplierService(DataContext context)
        {
            _context = context;
        }
        public void AddSupplier(Supplier supplier,int concernId, int userId)
        {
            supplier.Creator = userId;
            supplier.CreationDate = DateTime.Now;
            supplier.ConcernID = concernId;
            supplier.IsDelete = 0;
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public IEnumerable<ResponseSupplier> ResponseSuppliers(int concernId, int Page)
        {
            List<ResponseSupplier> responses = new List<ResponseSupplier>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_SupplierIndex @concernId,@Page";
                command.Parameters.Add(new SqlParameter("@concernId",concernId));
                command.Parameters.Add(new SqlParameter("@Page", Page));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while(result.Read())
                        {
                            responses.Add(new ResponseSupplier()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                SupplierID = Convert.ToInt32(result[1]),
                                SupplierName = Convert.ToString(result[2]),
                                SupplierAddress = Convert.ToString(result[3]),
                                MobileNumber = Convert.ToString(result[4]),
                                AlternateMobileNumber = Convert.ToString(result[5]),
                                SupplierBalance = Convert.ToDecimal(result[6]),
                                Description = Convert.ToString(result[7]),
                                NumberOfRow = Convert.ToInt32(result[8])
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