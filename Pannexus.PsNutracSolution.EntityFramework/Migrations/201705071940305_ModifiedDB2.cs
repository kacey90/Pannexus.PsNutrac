namespace Pannexus.PsNutrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "ReturnRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Investments", "InvestmentMaturityDate");
            DropColumn("dbo.Investments", "ExpectedTotalReturn");
            DropColumn("dbo.Investments", "ExpectedAmountPerPayment");
            DropColumn("dbo.Schemes", "DateCreated");
            DropColumn("dbo.Schemes", "UnsubscribedUnits");
            DropColumn("dbo.SchemePaymentDates", "IsPast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchemePaymentDates", "IsPast", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schemes", "UnsubscribedUnits", c => c.Int(nullable: false));
            AddColumn("dbo.Schemes", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Investments", "ExpectedAmountPerPayment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Investments", "ExpectedTotalReturn", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Investments", "InvestmentMaturityDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Investments", "ReturnRate", c => c.Double(nullable: false));
        }
    }
}
