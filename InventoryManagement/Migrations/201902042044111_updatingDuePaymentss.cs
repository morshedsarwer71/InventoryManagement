namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDuePaymentss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDuePayments", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseDuePayments", "Code");
        }
    }
}
