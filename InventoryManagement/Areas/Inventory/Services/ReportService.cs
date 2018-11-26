using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.ResponseModels;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Services
{
    public class ReportService : IReport
    {
        private readonly DataContext _context;
        public ReportService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<ResponseStockReport> ResponseStockReports(int concernId, int page)
        {
            List<ResponseStockReport> stockReports = new List<ResponseStockReport>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_InventoryManagementSystem_StockReport @concernId,@PageNo";
                command.Parameters.Add(new SqlParameter("@concernId",concernId));
                command.Parameters.Add(new SqlParameter("@PageNo", page));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            stockReports.Add(new ResponseStockReport()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                ProductId = Convert.ToInt32(result[1]),
                                ProductName = Convert.ToString(result[2]),
                                Input = Convert.ToDecimal(result[3]),
                                Output = Convert.ToDecimal(result[4]),
                                InStock = Convert.ToDecimal(result[5]),
                                Rows = Convert.ToInt32(result[6]),
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return stockReports;
        }
    }
}