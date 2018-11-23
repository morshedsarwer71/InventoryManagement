using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IPurchaseInvoice
    {
        void AddPurchaseInvoice(SessionInvoice sessionInvoice, int userId, int concernId);
        IEnumerable<ResponsePurchase> ResponsePurchases(int concernId, int page, string purchaseCode);
    }
}
