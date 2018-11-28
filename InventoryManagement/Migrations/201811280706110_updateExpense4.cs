namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseNames", "ConcerInId", c => c.Int(nullable: false));
            AddColumn("dbo.ExpenseNames", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ExpenseNames", "Creator", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseNames", "Creator");
            DropColumn("dbo.ExpenseNames", "CreationDate");
            DropColumn("dbo.ExpenseNames", "ConcerInId");
        }
    }
}
