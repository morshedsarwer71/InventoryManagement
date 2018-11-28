namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseNames", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseNames", "Payment");
        }
    }
}
