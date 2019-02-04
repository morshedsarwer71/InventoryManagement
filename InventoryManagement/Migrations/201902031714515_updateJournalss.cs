namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJournalss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "ExpensesCode", c => c.String());
            AddColumn("dbo.Journals", "ExpensesCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Journals", "ExpensesCode");
            DropColumn("dbo.Expenses", "ExpensesCode");
        }
    }
}
