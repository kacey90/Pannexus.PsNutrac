namespace Pannexus.PsNutrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemeModified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schemes", "SubscriptionCeiling");
            DropColumn("dbo.Schemes", "ActualSubscription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schemes", "ActualSubscription", c => c.Double(nullable: false));
            AddColumn("dbo.Schemes", "SubscriptionCeiling", c => c.Int(nullable: false));
        }
    }
}
