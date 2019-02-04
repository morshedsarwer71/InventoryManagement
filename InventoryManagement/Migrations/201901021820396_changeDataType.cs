namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "SalesPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "PurchasePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseInvoices", "PurchaseUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseInvoices", "SalesUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseReturnInvoices", "PRUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseReturnInvoices", "SalesUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.SalesInvoices", "SalesUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.SalesReturnInvoices", "SRUnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.SessionInvoices", "UnitPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SessionInvoices", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SalesReturnInvoices", "SRUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SalesInvoices", "SalesUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseReturnInvoices", "SalesUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseReturnInvoices", "PRUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseInvoices", "SalesUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseInvoices", "PurchaseUnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "SalesPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
