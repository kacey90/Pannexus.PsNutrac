namespace Pannexus.PsNutrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedInvestment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investments", "ReturnRate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investments", "ReturnRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
