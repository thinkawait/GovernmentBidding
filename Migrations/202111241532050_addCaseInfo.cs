namespace GovernmentBidding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCaseInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AgencyCode = c.String(nullable: false),
                        AgencyName = c.String(nullable: false),
                        UnitName = c.String(nullable: false),
                        AgencyAddr = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false),
                        Fax = c.String(nullable: false),
                        ContactMail = c.String(nullable: false),
                        CaseNumber = c.String(nullable: false),
                        CaseName = c.String(nullable: false),
                        CaseClassify = c.String(nullable: false),
                        NatureOfPurchase = c.String(nullable: false),
                        GoldRating = c.String(nullable: false),
                        Handle = c.String(nullable: false),
                        Flap = c.String(nullable: false),
                        isGPA = c.Boolean(nullable: false),
                        isANZTEC = c.Boolean(nullable: false),
                        isASTEP = c.Boolean(nullable: false),
                        isSensitive = c.Boolean(nullable: false),
                        isNationalSecurity = c.Boolean(nullable: false),
                        Budget = c.Int(nullable: false),
                        isPublic = c.Boolean(nullable: false),
                        isExpansion = c.Boolean(nullable: false),
                        isSubsidy = c.Boolean(nullable: false),
                        SubsidyName = c.String(),
                        SubsidyAmount = c.Int(),
                        isSpecialBudget = c.Boolean(nullable: false),
                        TenderMethod = c.String(nullable: false),
                        BressesMethod = c.String(nullable: false),
                        is64to2 = c.Boolean(nullable: false),
                        PublishCount = c.Int(nullable: false),
                        BiddingStatus = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        isPluralDecoration = c.Boolean(nullable: false),
                        isBasePrice = c.Boolean(nullable: false),
                        isInclubePrice = c.Boolean(nullable: false),
                        isWriteCost = c.Boolean(nullable: false),
                        isSpecialPurchase = c.Boolean(nullable: false),
                        isOpenView = c.Boolean(nullable: false),
                        isPacket = c.Boolean(nullable: false),
                        isContractPurchase = c.Boolean(nullable: false),
                        isTwoAgency = c.Boolean(nullable: false),
                        isTechnicianVisa = c.Boolean(nullable: false),
                        isConsultationMeasures = c.Boolean(nullable: false),
                        isPurchaseMethod104or105 = c.Boolean(nullable: false),
                        isPurchaseMethod106 = c.Boolean(nullable: false),
                        isElectronics = c.Boolean(nullable: false),
                        isEBidding = c.Boolean(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OpeningTime = c.DateTime(nullable: false),
                        OpeningAddr = c.String(nullable: false),
                        BiddingGold = c.String(nullable: false),
                        TenderWriting = c.String(nullable: false),
                        TenderAddr = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CaseInfoes");
        }
    }
}
