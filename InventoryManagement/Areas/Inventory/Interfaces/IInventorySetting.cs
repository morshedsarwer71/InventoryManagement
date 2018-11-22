﻿using InventoryManagement.Areas.Inventory.Models;
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
        IEnumerable<Unit> Units(int concernId);

        //Category
        void AddCategory(Category category,int userId,int concernId);
        void DeleteCategory(int categoryId, int userId, int concernId);
        void UpdateCategory(Category category,int categoryId, int userId, int concernId);
        IEnumerable<Category> Categories(int concernId);

        //Product

        void AddProduct(Product product, int userId, int concernId);
        void DeleteProduct(int productId, int userId, int concernId);
        void UpdateProduct(Product product,int productId, int userId, int concernId);
        IEnumerable<ResponseProduct> Products(int concernId,int page);

        //product and supplier and buyer data pull

        IEnumerable<Product> Products(int concernId);
        IEnumerable<Buyer> Buyers(int concernId);
        IEnumerable<Supplier> Suppliers(int concernId);

    }
}
