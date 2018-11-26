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
    }
}
