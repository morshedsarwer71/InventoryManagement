namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJournalssdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journals", "VoucherCode", c => c.String(nullable: false));
            AddColumn("dbo.ReportHeads", "ConcernId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountsHeads", "AccountsHeadNameEN", c => c.String(nullable: false));
            AlterColumn("dbo.AccountsHeads", "AccountsHeadNameAR", c => c.String(nullable: false));
            AlterColumn("dbo.Journals", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ReportHeads", "ReportHeadNameEN", c => c.String(nullable: false));
            AlterColumn("dbo.ReportHeads", "ReportHeadNameAR", c => c.String(nullable: false));
            DropColumn("dbo.Journals", "ExpensesCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Journals", "ExpensesCode", c => c.String());
            AlterColumn("dbo.ReportHeads", "ReportHeadNameAR", c => c.String());
            AlterColumn("dbo.ReportHeads", "ReportHeadNameEN", c => c.String());
            AlterColumn("dbo.Journals", "Description", c => c.String());
            AlterColumn("dbo.AccountsHeads", "AccountsHeadNameAR", c => c.String());
            AlterColumn("dbo.AccountsHeads", "AccountsHeadNameEN", c => c.String());
            DropColumn("dbo.ReportHeads", "ConcernId");
            DropColumn("dbo.Journals", "VoucherCode");
        }
    }
}
