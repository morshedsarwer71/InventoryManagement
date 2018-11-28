namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExpenseTypes", "ExpenseTypeName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExpenseTypes", "ExpenseTypeName", c => c.Int(nullable: false));
        }
    }
}
