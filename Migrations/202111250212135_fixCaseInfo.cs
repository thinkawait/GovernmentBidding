namespace GovernmentBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCaseInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaseInfoes", "isBudgetPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "EstimatedAmount", c => c.Int(nullable: false));
            AddColumn("dbo.CaseInfoes", "isEstimatedAmountPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "ExpansionDescribe", c => c.String());
            DropColumn("dbo.CaseInfoes", "isPublic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaseInfoes", "isPublic", c => c.Boolean(nullable: false));
            DropColumn("dbo.CaseInfoes", "ExpansionDescribe");
            DropColumn("dbo.CaseInfoes", "isEstimatedAmountPublic");
            DropColumn("dbo.CaseInfoes", "EstimatedAmount");
            DropColumn("dbo.CaseInfoes", "isBudgetPublic");
        }
    }
}
