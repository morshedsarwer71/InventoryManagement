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

        public IEnumerable<ResponseDuesSummary> ResponseBuyerDuesSummaries(int concernId)
        {
            List<ResponseDuesSummary> responses = new List<ResponseDuesSummary>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_InventoryManagementSystem_BuyersDuepaymentSummary @concernId";
                command.Parameters.Add(new SqlParameter("@concernId",concernId));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseDuesSummary()
                            {
                                Id=Convert.ToInt32(result[0]),
                                Name=Convert.ToString(result[1]),
                                TotalDues=Convert.ToDecimal(result[2]),
                                TotalPaid=Convert.ToDecimal(result[3]),
                                PreviousBalance=Convert.ToDecimal(result[4]),
                                GrandDues=Convert.ToDecimal(result[5]),
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
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

        public IEnumerable<ResponseDuesSummary> ResponseSupplierDuesSummaries(int concernId)
        {
            List<ResponseDuesSummary> responses = new List<ResponseDuesSummary>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_InventoryManagementSystem_SuppliersDuePaymentSummary @concernId";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseDuesSummary()
                            {
                                Id = Convert.ToInt32(result[0]),
                                Name = Convert.ToString(result[1]),
                                TotalDues = Convert.ToDecimal(result[2]),
                                TotalPaid = Convert.ToDecimal(result[3]),
                                PreviousBalance = Convert.ToDecimal(result[4]),
                                GrandDues = Convert.ToDecimal(result[5]),
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