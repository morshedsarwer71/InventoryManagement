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

        public IEnumerable<ResponseExpense> ResponseExpensesHead(int concernId, int id, string fromDate, string toDate)
        {
            List<ResponseExpense> responses = new List<ResponseExpense>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Reporting_InnventoryManagement_Expense_Head_Report @ConcernId,@ExpenseTypeId,@fromDate,@toDate";
                command.Parameters.Add(new SqlParameter("@ConcernId", concernId));
                command.Parameters.Add(new SqlParameter("@ExpenseTypeId", id));
                command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                command.Parameters.Add(new SqlParameter("@toDate", toDate));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseExpense() {
                                Serial=Convert.ToInt32(result[0]),
                                ExpenseId=Convert.ToInt32(result[1]),
                                Id=Convert.ToInt32(result[2]),
                                ExpenseHead=Convert.ToString(result[3]),
                                ExpenseType=Convert.ToString(result[4]),
                                Date=Convert.ToString(result[5]),
                                Payment=Convert.ToDecimal(result[6])
                            });
                        }
                    }
                }
                    _context.Database.Connection.Close();
            }
                return responses;
        }

        public IEnumerable<ResponseExpense> ResponseExpensesName(int concernId, int id, string fromDate, string toDate)
        {
            List<ResponseExpense> responses = new List<ResponseExpense>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "Reporting_InnventoryManagement_Expense_Name_Report @ConcernId,@ExpenseTypeId,@fromDate,@toDate";
                command.Parameters.Add(new SqlParameter("@ConcernId", concernId));
                command.Parameters.Add(new SqlParameter("@ExpenseTypeId", id));
                command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                command.Parameters.Add(new SqlParameter("@toDate", toDate));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseExpense()
                            {
                                Serial = Convert.ToInt32(result[0]),
                                ExpenseId = Convert.ToInt32(result[1]),
                                Id = Convert.ToInt32(result[2]),
                                ExpenseHead = Convert.ToString(result[3]),
                                ExpenseType = Convert.ToString(result[4]),
                                Date = Convert.ToString(result[5]),
                                Payment = Convert.ToDecimal(result[6])
                            });
                        }
                    }
                }
                _context.Database.Connection.Close();
            }
            return responses;
        }

        public IEnumerable<ResponseInvoiceReport> ResponseInvoiceReports(int concernId, string fromDate, string toDate, int vendorId, int Status,int SalesType)
        {
            List<ResponseInvoiceReport> invoiceReports = new List<ResponseInvoiceReport>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Reporting_InventoryManagement_SalesInvoiceCombinedReport @ConcernID,@fDate,@tDate,@Customerid,@PaymentStatus,@SalesType";
                command.Parameters.Add(new SqlParameter("@concernID", concernId));
                command.Parameters.Add(new SqlParameter("@fDate", fromDate));
                command.Parameters.Add(new SqlParameter("@tDate", toDate));
                command.Parameters.Add(new SqlParameter("@Customerid", vendorId));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", Status));
                command.Parameters.Add(new SqlParameter("@SalesType", SalesType));
                _context.Database.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                        while (result.Read())
                        {
                            invoiceReports.Add(new ResponseInvoiceReport()
                            {
                                Date=Convert.ToString(result[0]),
                                Code=Convert.ToString(result[1]),
                                Name=Convert.ToString(result[2]),
                                Id=Convert.ToInt32(result[3]),
                                Items=Convert.ToInt32(result[4]),
                                TotalPrice=Convert.ToInt32(result[5]),
                                Cash=Convert.ToDecimal(result[6]),
                                Discount=Convert.ToDecimal(result[7]),
                                Dues=Convert.ToDecimal(result[8]),
                                SalesType=Convert.ToInt32(result[9]),
                                SalesTypeName=Convert.ToString(result[10])
                            });
                        }
                }
                _context.Database.Connection.Close();
            }
                return invoiceReports;
        }

        public IEnumerable<ResponseInvoiceReport> ResponsePurchaseInvoiceReports(int concernId, string fromDate, string toDate, int vendorId, int Status, int SalesType)
        {
            List<ResponseInvoiceReport> invoiceReports = new List<ResponseInvoiceReport>();
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Reporting_InventoryManagement_PurchaseInvoiceCombinedReport @ConcernID,@fDate,@tDate,@Customerid,@PaymentStatus,@SalesType";
                command.Parameters.Add(new SqlParameter("@concernID", concernId));
                command.Parameters.Add(new SqlParameter("@fDate", fromDate));
                command.Parameters.Add(new SqlParameter("@tDate", toDate));
                command.Parameters.Add(new SqlParameter("@Customerid", vendorId));
                command.Parameters.Add(new SqlParameter("@PaymentStatus", Status));
                command.Parameters.Add(new SqlParameter("@SalesType", SalesType));
                _context.Database.Connection.Open();
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                        while (result.Read())
                        {
                            invoiceReports.Add(new ResponseInvoiceReport()
                            {
                                Date = Convert.ToString(result[0]),
                                Code = Convert.ToString(result[1]),
                                Name = Convert.ToString(result[2]),
                                Id = Convert.ToInt32(result[3]),
                                Items = Convert.ToInt32(result[4]),
                                TotalPrice = Convert.ToInt32(result[5]),
                                Cash = Convert.ToDecimal(result[6]),
                                Discount = Convert.ToDecimal(result[7]),
                                Dues = Convert.ToDecimal(result[8]),
                                SalesType = Convert.ToInt32(result[9]),
                                SalesTypeName = Convert.ToString(result[10])
                            });
                        }
                }
                _context.Database.Connection.Close();
            }
            return invoiceReports;
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