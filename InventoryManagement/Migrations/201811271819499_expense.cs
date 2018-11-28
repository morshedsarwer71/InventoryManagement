namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseNames",
                c => new
                    {
                        ExpenseNameId = c.Int(nullable: false, identity: true),
                        ExpenseHead = c.String(),
                        ExpenseType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseNameId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        ExpenseNameId = c.Int(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ConcernId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseNames");
        }
    }
}
