using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IPurchaseReturn
    {
        void AddPurchaseInvoice(SessionInvoice sessionInvoice, int userId, int concernId);
        IEnumerable<ResponsePurchaseReturn> ResponsePurchases(int concernId, int page, string purchaseCode);
    }
}
