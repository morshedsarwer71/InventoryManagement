namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseNames", "PaymentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseNames", "PaymentType");
        }
    }
}
