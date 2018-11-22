using InventoryManagement.Areas.Inventory.Interfaces;
using InventoryManagement.Areas.Inventory.Models;
using InventoryManagement.Areas.Inventory.ResponseModels;
using InventoryManagement.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagement.Areas.Inventory.Services
{
    public class InventorySettingService : IInventorySetting
    {
        private readonly DataContext _context;
        public InventorySettingService(DataContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category, int userId, int concernId)
        {
            category.CategoryID = userId;
            category.ConcernID = concernId;
            category.CreationDate = DateTime.Now;
            category.IsDelete = 0;
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void AddProduct(Product product, int userId, int concernId)
        {
            product.CategoryID = userId;
            product.ConcernID = concernId;
            product.CreationDate = DateTime.Now;
            product.IsDelete = 0;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void AddUnit(Unit unit, int userId, int concernId)
        {
            unit.Creator = userId;
            unit.ConcernID = concernId;
            unit.CreationDate = DateTime.Now;
            unit.IsDelete = 0;
        }

        public IEnumerable<Category> Categories(int concernId)
        {
            return _context.Categories.Where(m=>m.IsDelete==0 && m.ConcernID==concernId);
        }

        public void DeleteCategory(int categoryId, int userId, int concernId)
        {
            var category = _context.Categories.FirstOrDefault(m=>m.CategoryID==categoryId && m.IsDelete==0);
            category.IsDelete = 1;
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId, int userId, int concernId)
        {
            var product = _context.Products.FirstOrDefault(m=>m.IsDelete==0 && m.ProductID==productId);
            product.IsDelete = 1;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteUnit(int unitId, int concernId, int userId)
        {
            var unit = _context.Units.FirstOrDefault();
        }

        public IEnumerable<ResponseProduct> Products(int concernId,int page)
        {
            List<ResponseProduct> responses = new List<ResponseProduct>();
            using (var command=_context.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_Inventory_StockManagement_ProductIndex @concernId,@Page";
                command.Parameters.Add(new SqlParameter("@concernId", concernId));
                command.Parameters.Add(new SqlParameter("@Page", page));
                command.Connection.Open();
                using (var result=command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            responses.Add(new ResponseProduct() {
                                Serial=Convert.ToInt32(result[0]),
                                ProductId=Convert.ToInt32(result[1]),
                                ProductCode=Convert.ToString(result[2]),
                                ProductName=Convert.ToString(result[3]),
                                UnitName=Convert.ToString(result[4]),
                                CategoryName=Convert.ToString(result[5]),
                                Quantity=Convert.ToDecimal(result[6]),
                                SalesPrice=Convert.ToDecimal(result[7]),
                                PurchasePrice=Convert.ToDecimal(result[8]),
                                Description=Convert.ToString(result[9]),
                                Rows=Convert.ToInt32(result[10]),
                            });
                        }
                    }
                }
                command.Connection.Close();
            }
                return responses;
        }

        public IEnumerable<Unit> Units(int concernId)
        {
            return _context.Units.Where(m => m.ConcernID == concernId && m.IsDelete == 0);
        }

        public void UpdateCategory(Category category, int categoryId, int userId, int concernId)
        {
            var Category = _context.Categories.FirstOrDefault(m=>m.CategoryID==categoryId && m.IsDelete==0);
            Category.CategoryName = category.CategoryName;
            Category.Description = category.Description;
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product,int productId, int userId, int concernId)
        {
            var updateProduct = _context.Products.FirstOrDefault(m=>m.ProductID==productId && m.ConcernID==concernId);
            updateProduct.CategoryID = product.CategoryID;
            updateProduct.Description = product.Description;
            updateProduct.ProductName = product.ProductName;
            updateProduct.PurchasePrice = product.PurchasePrice;
            updateProduct.Quantity = product.Quantity;
            updateProduct.SalesPrice = product.SalesPrice;
            updateProduct.UnitID = product.UnitID;
            _context.SaveChanges();
        }

        public void UpdateUnit(int unitId, Unit unit, int userId, int concernId)
        {
            var updateUnit = _context.Units.FirstOrDefault(m=>m.UnitID==unitId && m.IsDelete==0);
            updateUnit.UnitName = unit.UnitName;
            updateUnit.Description = unit.Description;
            _context.SaveChanges();
        }
    }
}