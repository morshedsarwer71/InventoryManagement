using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IDuePayment
    {
        //sales payment

        void AddBuyerPayment(SalesDuePayment salesDuePayment,int concernId,int userId);
        IEnumerable<ResponseDuePayment> BuyerDuePayments(int concernId,int page);

        //supplier payment

        void AddSupplierPayment(PurchaseDuePayment purchaseDuePayment, int concernId, int userId);
        IEnumerable<ResponseDuePayment> SupplierDuePayments(int concernId, int page);
    }
}
