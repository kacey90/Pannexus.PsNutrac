namespace Pannexus.PsNutrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "Gender", c => c.String(maxLength: 7));
            AddColumn("dbo.AbpUsers", "Occupation", c => c.String(maxLength: 150));
            AddColumn("dbo.AbpUsers", "Designation", c => c.String(maxLength: 100));
            AddColumn("dbo.AbpUsers", "City", c => c.String(maxLength: 100));
            AddColumn("dbo.AbpUsers", "State", c => c.String(maxLength: 100));
            AddColumn("dbo.AbpUsers", "Bank", c => c.String(maxLength: 100));
            AddColumn("dbo.AbpUsers", "SortCode", c => c.String(maxLength: 20));
            AddColumn("dbo.AbpUsers", "AccountNumber", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "AccountNumber");
            DropColumn("dbo.AbpUsers", "SortCode");
            DropColumn("dbo.AbpUsers", "Bank");
            DropColumn("dbo.AbpUsers", "State");
            DropColumn("dbo.AbpUsers", "City");
            DropColumn("dbo.AbpUsers", "Designation");
            DropColumn("dbo.AbpUsers", "Occupation");
            DropColumn("dbo.AbpUsers", "Gender");
        }
    }
}
