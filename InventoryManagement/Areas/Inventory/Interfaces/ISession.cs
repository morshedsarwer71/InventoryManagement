using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface ISession
    {
        void AddSessionInvoice(int userId,int concernId, SessionInvoice sessionInvoice);
        void Delete(int userId,int concernId,int sessionId);
        void ClearSessionInvoice(int userId,int ConcernId);
        IEnumerable<ResponseSession> ResponseSessions(int concernId,int userId);
        Product ProductPrice(int productId,int concernId);
    }
}
