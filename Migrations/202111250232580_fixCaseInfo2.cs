namespace GovernmentBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCaseInfo2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CaseInfoes", "AgencyCode");
            DropColumn("dbo.CaseInfoes", "UnitName");
            DropColumn("dbo.CaseInfoes", "AgencyAddr");
            DropColumn("dbo.CaseInfoes", "ContactPerson");
            DropColumn("dbo.CaseInfoes", "ContactPhone");
            DropColumn("dbo.CaseInfoes", "Fax");
            DropColumn("dbo.CaseInfoes", "ContactMail");
            DropColumn("dbo.CaseInfoes", "NatureOfPurchase");
            DropColumn("dbo.CaseInfoes", "GoldRating");
            DropColumn("dbo.CaseInfoes", "Handle");
            DropColumn("dbo.CaseInfoes", "Flap");
            DropColumn("dbo.CaseInfoes", "isGPA");
            DropColumn("dbo.CaseInfoes", "isANZTEC");
            DropColumn("dbo.CaseInfoes", "isASTEP");
            DropColumn("dbo.CaseInfoes", "isSensitive");
            DropColumn("dbo.CaseInfoes", "isNationalSecurity");
            DropColumn("dbo.CaseInfoes", "isBudgetPublic");
            DropColumn("dbo.CaseInfoes", "EstimatedAmount");
            DropColumn("dbo.CaseInfoes", "isEstimatedAmountPublic");
            DropColumn("dbo.CaseInfoes", "isExpansion");
            DropColumn("dbo.CaseInfoes", "ExpansionDescribe");
            DropColumn("dbo.CaseInfoes", "isSubsidy");
            DropColumn("dbo.CaseInfoes", "SubsidyName");
            DropColumn("dbo.CaseInfoes", "SubsidyAmount");
            DropColumn("dbo.CaseInfoes", "isSpecialBudget");
            DropColumn("dbo.CaseInfoes", "BressesMethod");
            DropColumn("dbo.CaseInfoes", "is64to2");
            DropColumn("dbo.CaseInfoes", "BiddingStatus");
            DropColumn("dbo.CaseInfoes", "isPluralDecoration");
            DropColumn("dbo.CaseInfoes", "isBasePrice");
            DropColumn("dbo.CaseInfoes", "isInclubePrice");
            DropColumn("dbo.CaseInfoes", "isWriteCost");
            DropColumn("dbo.CaseInfoes", "isSpecialPurchase");
            DropColumn("dbo.CaseInfoes", "isOpenView");
            DropColumn("dbo.CaseInfoes", "isPacket");
            DropColumn("dbo.CaseInfoes", "isContractPurchase");
            DropColumn("dbo.CaseInfoes", "isTwoAgency");
            DropColumn("dbo.CaseInfoes", "isTechnicianVisa");
            DropColumn("dbo.CaseInfoes", "isConsultationMeasures");
            DropColumn("dbo.CaseInfoes", "isPurchaseMethod104or105");
            DropColumn("dbo.CaseInfoes", "isPurchaseMethod106");
            DropColumn("dbo.CaseInfoes", "isElectronics");
            DropColumn("dbo.CaseInfoes", "isEBidding");
            DropColumn("dbo.CaseInfoes", "OpeningTime");
            DropColumn("dbo.CaseInfoes", "OpeningAddr");
            DropColumn("dbo.CaseInfoes", "BiddingGold");
            DropColumn("dbo.CaseInfoes", "TenderWriting");
            DropColumn("dbo.CaseInfoes", "TenderAddr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaseInfoes", "TenderAddr", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "TenderWriting", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "BiddingGold", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "OpeningAddr", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "OpeningTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CaseInfoes", "isEBidding", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isElectronics", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isPurchaseMethod106", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isPurchaseMethod104or105", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isConsultationMeasures", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isTechnicianVisa", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isTwoAgency", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isContractPurchase", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isPacket", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isOpenView", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isSpecialPurchase", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isWriteCost", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isInclubePrice", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isBasePrice", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isPluralDecoration", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "BiddingStatus", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "is64to2", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "BressesMethod", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "isSpecialBudget", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "SubsidyAmount", c => c.Int());
            AddColumn("dbo.CaseInfoes", "SubsidyName", c => c.String());
            AddColumn("dbo.CaseInfoes", "isSubsidy", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "ExpansionDescribe", c => c.String());
            AddColumn("dbo.CaseInfoes", "isExpansion", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isEstimatedAmountPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "EstimatedAmount", c => c.Int(nullable: false));
            AddColumn("dbo.CaseInfoes", "isBudgetPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isNationalSecurity", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isSensitive", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isASTEP", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isANZTEC", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "isGPA", c => c.Boolean(nullable: false));
            AddColumn("dbo.CaseInfoes", "Flap", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "Handle", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "GoldRating", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "NatureOfPurchase", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "ContactMail", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "Fax", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "ContactPhone", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "ContactPerson", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "AgencyAddr", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "UnitName", c => c.String(nullable: false));
            AddColumn("dbo.CaseInfoes", "AgencyCode", c => c.String(nullable: false));
        }
    }
}
