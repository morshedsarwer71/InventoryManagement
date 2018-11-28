namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseTypes", "ConcernId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseTypes", "ConcernId");
        }
    }
}
