namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpense5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        ExpenseTypeId = c.Int(nullable: false, identity: true),
                        ExpenseTypeName = c.Int(nullable: false),
                        ExReportHead = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseTypeId);
            
            AddColumn("dbo.ExpenseNames", "ExpenseTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.ExpenseNames", "ExpenseType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseNames", "ExpenseType", c => c.Int(nullable: false));
            DropColumn("dbo.ExpenseNames", "ExpenseTypeId");
            DropTable("dbo.ExpenseTypes");
        }
    }
}
