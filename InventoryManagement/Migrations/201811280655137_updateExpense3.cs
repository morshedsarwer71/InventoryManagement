namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExpenseNames", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseNames", "PaymentType", c => c.Int(nullable: false));
        }
    }
}
