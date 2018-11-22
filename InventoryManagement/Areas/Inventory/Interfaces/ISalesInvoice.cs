using InventoryManagement.Areas.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface ISalesInvoice
    {
        void AddSalesInvoice(SessionInvoice sessionInvoice,int userId,int concernId);
    }
}
