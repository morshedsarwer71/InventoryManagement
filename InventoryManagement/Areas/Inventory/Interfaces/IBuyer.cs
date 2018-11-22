using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IBuyer
    {
        void Add(Buyer buyer);
        IEnumerable<ResponseBuyer> Buyers(int concernId,int page);
        void Delete(int id,int concernId);
    }
}
