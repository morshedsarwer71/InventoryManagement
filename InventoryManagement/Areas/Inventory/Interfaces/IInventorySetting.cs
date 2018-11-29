using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Areas.Inventory.Interfaces
{
    public interface IInventorySetting
    {
        //Unit
        void AddUnit(Unit unit,int userId,int concernId);
        void DeleteUnit(int unitId,int concernId,int userId);
        void UpdateUnit(int unitId,Unit unit,int userId,int concernId);
        Unit Unit(int id);
        IEnumerable<Unit> Units(int concernId);

        //Category

        void AddCategory(Category category,int userId,int concernId);
        void DeleteCategory(int categoryId, int userId, int concernId);
        void UpdateCategory(Category category,int categoryId, int userId, int concernId);
        Category Category(int id);
        IEnumerable<Category> Categories(int concernId);

        //Product

        void AddProduct(Product product, int userId, int concernId);
        void DeleteProduct(int productId, int userId, int concernId);
        void UpdateProduct(Product product,int productId, int userId, int concernId);
        Product Product(int id);
        IEnumerable<ResponseProduct> Products(int concernId,int page);

        //product and supplier and buyer data pull

        IEnumerable<Product> Products(int concernId);
        IEnumerable<Buyer> Buyers(int concernId);
        IEnumerable<Supplier> Suppliers(int concernId);

        //expense

        void AddExpenseName(ExpenseName expenseName,int concernId,int userId);
        IEnumerable<ExpenseName> ExpenseNames(int concernId);
        void AddExpense(Expense expense,int concernId,int userId);
        IEnumerable<ResponseExpenses> ResponseExpenses(int concernId,int Page);
        IEnumerable<ExpenseType> ExpenseTypes(int concernId);

    }
}
