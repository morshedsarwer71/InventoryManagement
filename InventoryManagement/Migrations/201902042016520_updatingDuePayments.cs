namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDuePayments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesDuePayments", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesDuePayments", "Code");
        }
    }
}
