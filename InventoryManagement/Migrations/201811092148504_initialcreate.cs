namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountsHeads",
                c => new
                    {
                        AccountsHeadId = c.Int(nullable: false, identity: true),
                        AccountsHeadNameEN = c.String(),
                        ReportHeadId = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ModifierId = c.Int(nullable: false),
                        AccountsHeadNameAR = c.String(),
                        ConcernId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountsHeadId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerID = c.Int(nullable: false, identity: true),
                        BuyerName = c.String(),
                        BuyerAddress = c.String(nullable: false),
                        BuyerBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        AlternateMobileNumber = c.String(),
                        MobileNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentCategoryID = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Concerns",
                c => new
                    {
                        ConcernId = c.Int(nullable: false, identity: true),
                        ConcernNameAR = c.String(),
                        ConcernNameEN = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ModifierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConcernId);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        JournalId = c.Int(nullable: false, identity: true),
                        ConcernId = c.Int(nullable: false),
                        CreditAccountsHeadId = c.Int(nullable: false),
                        CreditJournalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAccountsHeadId = c.Int(nullable: false),
                        DebitJournalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        JournalEntryDate = c.DateTime(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        JournalCreationDate = c.DateTime(nullable: false),
                        JournalCreator = c.Int(nullable: false),
                        JournalModificationDate = c.DateTime(nullable: false),
                        JournalModifierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JournalId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ProductCode = c.String(),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.PurchaseDuePayments",
                c => new
                    {
                        PurchaseDuePaymentID = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseDuePaymentID);
            
            CreateTable(
                "dbo.PurchaseInvoices",
                c => new
                    {
                        PurchaseInvoiceID = c.Int(nullable: false, identity: true),
                        PurchaseInvoiceCode = c.String(),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        CashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DuePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseInvoiceID);
            
            CreateTable(
                "dbo.PurchaseReturnInvoices",
                c => new
                    {
                        PRInvoiceID = c.Int(nullable: false, identity: true),
                        PRInvoiceCode = c.String(),
                        PurchaseInvoiceCode = c.String(),
                        PRProductID = c.Int(nullable: false),
                        PRQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRSupplierID = c.Int(nullable: false),
                        PRDate = c.DateTime(nullable: false),
                        PRCashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRDuePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PRDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PRInvoiceID);
            
            CreateTable(
                "dbo.ReportHeads",
                c => new
                    {
                        ReportHeadId = c.Int(nullable: false, identity: true),
                        ReportHeadNameEN = c.String(),
                        ReportType = c.Int(nullable: false),
                        ReportHeadNameAR = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                        ModifierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportHeadId);
            
            CreateTable(
                "dbo.SalesDuePayments",
                c => new
                    {
                        SalesDuePaymentID = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        BuyerID = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesDuePaymentID);
            
            CreateTable(
                "dbo.SalesInvoices",
                c => new
                    {
                        SalesInvoiceID = c.Int(nullable: false, identity: true),
                        SalesInvoiceCode = c.String(),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerID = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        CashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DuePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalesInvoiceID);
            
            CreateTable(
                "dbo.SalesReturnInvoices",
                c => new
                    {
                        SRInvoiceID = c.Int(nullable: false, identity: true),
                        SRInvoiceCode = c.String(),
                        SRProductID = c.Int(nullable: false),
                        SRQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SRUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SRCashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SRDuePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SRDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SRBuyerID = c.Int(nullable: false),
                        SRDate = c.DateTime(nullable: false),
                        SalesInvoiceCode = c.String(),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SRInvoiceID);
            
            CreateTable(
                "dbo.SessionInvoices",
                c => new
                    {
                        SessionInvoiceID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DuePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionInvoiceID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        SupplierAddress = c.String(nullable: false),
                        SupplierBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConcernID = c.Int(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        AlternateMobileNumber = c.String(),
                        MobileNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        IsDisabled = c.Int(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        EmailAddress = c.String(),
                        LoginFailedCount = c.Int(nullable: false),
                        Language = c.String(),
                        ActivationDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        HashSalt = c.String(),
                        CreatorId = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Units");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SessionInvoices");
            DropTable("dbo.SalesReturnInvoices");
            DropTable("dbo.SalesInvoices");
            DropTable("dbo.SalesDuePayments");
            DropTable("dbo.ReportHeads");
            DropTable("dbo.PurchaseReturnInvoices");
            DropTable("dbo.PurchaseInvoices");
            DropTable("dbo.PurchaseDuePayments");
            DropTable("dbo.Products");
            DropTable("dbo.Journals");
            DropTable("dbo.Concerns");
            DropTable("dbo.Categories");
            DropTable("dbo.Buyers");
            DropTable("dbo.AccountsHeads");
        }
    }
}
