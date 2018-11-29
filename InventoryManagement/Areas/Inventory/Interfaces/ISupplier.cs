using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface ISupplier
    {
        void AddSupplier(Supplier supplier,int concernId, int userId);
        IEnumerable<ResponseSupplier> ResponseSuppliers(int concernId,int Page);
    }
}
