using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IReport
    {
        IEnumerable<ResponseStockReport> ResponseStockReports(int concernId,int page);
        IEnumerable<ResponseDuesSummary> ResponseBuyerDuesSummaries(int concernId);
        IEnumerable<ResponseDuesSummary> ResponseSupplierDuesSummaries(int concernId);
        IEnumerable<ResponseInvoiceReport> ResponseInvoiceReports(int concernId,string fromDate,string toDate,int vendorId,int Status,int SalesType);
        IEnumerable<ResponseInvoiceReport> ResponsePurchaseInvoiceReports(int concernId,string fromDate,string toDate,int vendorId,int Status,int SalesType);
        IEnumerable<ResponseExpense> ResponseExpensesName(int concernId,int id,string fromDate,string toDate);
        IEnumerable<ResponseExpense> ResponseExpensesHead(int concernId,int id,string fromDate,string toDate);
        IEnumerable<ResponsePaymentReport> BuyerDuPaymentReport(int concernId,int id,string fromDate,string toDate);
        IEnumerable<ResponsePaymentReport> SupplierDuPaymentReport(int concernId,int id,string fromDate,string toDate);
    }
}
