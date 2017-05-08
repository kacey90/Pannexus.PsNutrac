namespace Pannexus.PsNutrac.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class PsNutracInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            CreateTable(
                "dbo.AccountCharts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(nullable: false, maxLength: 50),
                        SortCode = c.String(maxLength: 20),
                        AccountNumber = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        TotalCreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AccountChart_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankCode = c.String(nullable: false, maxLength: 3),
                        BankName = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Bank_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        InvestmentID = c.String(nullable: false, maxLength: 128),
                        SchemeId = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                        BankId = c.String(nullable: false, maxLength: 128),
                        CreditBank = c.String(nullable: false, maxLength: 20),
                        SortCode = c.String(maxLength: 20),
                        CreditAccount = c.String(nullable: false, maxLength: 20),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Message = c.String(nullable: false, maxLength: 50),
                        AccountChartId = c.String(nullable: false, maxLength: 128),
                        DebitBankName = c.String(nullable: false, maxLength: 50),
                        DebitBankAccountNumber = c.String(nullable: false, maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Investment_Id = c.String(maxLength: 128),
                        Scheme_Id = c.String(maxLength: 128),
                        AccountChart_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Payment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountCharts", t => t.AccountChartId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Investments", t => t.Investment_Id)
                .ForeignKey("dbo.Schemes", t => t.Scheme_Id)
                .ForeignKey("dbo.Investments", t => t.InvestmentID)
                .ForeignKey("dbo.Schemes", t => t.SchemeId)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .ForeignKey("dbo.AccountCharts", t => t.AccountChart_Id)
                .Index(t => t.InvestmentID)
                .Index(t => t.SchemeId)
                .Index(t => t.UserId)
                .Index(t => t.BankId)
                .Index(t => t.AccountChartId)
                .Index(t => t.Investment_Id)
                .Index(t => t.Scheme_Id)
                .Index(t => t.AccountChart_Id);
            
            CreateTable(
                "dbo.Investments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                        SchemeId = c.String(nullable: false, maxLength: 128),
                        SchemeName = c.String(nullable: false, maxLength: 50),
                        InvestmentUnit = c.Int(nullable: false),
                        InvestmentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvestmentDate = c.DateTime(nullable: false),
                        InvestmentStartDate = c.DateTime(nullable: false),
                        InvestmentMaturityDate = c.DateTime(nullable: false),
                        ReturnRate = c.Double(nullable: false),
                        TenorID = c.String(nullable: false, maxLength: 128),
                        TenorInDays = c.Int(nullable: false),
                        PaymentPeriodID = c.String(nullable: false, maxLength: 128),
                        PaymentPeriodInDays = c.Int(nullable: false),
                        ExpectedTotalReturn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoOfTotalPayments = c.Double(nullable: false),
                        ExpectedAmountPerPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoOfTotalPaymentMade = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Scheme_Id = c.String(maxLength: 128),
                        Tenor_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Investment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentPeriods", t => t.PaymentPeriodID)
                .ForeignKey("dbo.Schemes", t => t.Scheme_Id)
                .ForeignKey("dbo.Tenors", t => t.Tenor_Id)
                .ForeignKey("dbo.Schemes", t => t.SchemeId)
                .ForeignKey("dbo.Tenors", t => t.TenorID)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SchemeId)
                .Index(t => t.TenorID)
                .Index(t => t.PaymentPeriodID)
                .Index(t => t.Scheme_Id)
                .Index(t => t.Tenor_Id);
            
            CreateTable(
                "dbo.PaymentPeriods",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PeriodInDays = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PaymentPeriod_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schemes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SchemeCode = c.String(nullable: false, maxLength: 3),
                        SchemeName = c.String(nullable: false, maxLength: 50),
                        CropId = c.String(nullable: false, maxLength: 128),
                        CropName = c.String(nullable: false, maxLength: 50),
                        TotalSchemeUnits = c.Int(nullable: false),
                        ValuePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FloorInvestUnit = c.Int(nullable: false),
                        CeilingInvestUnit = c.Int(nullable: false),
                        SubscriptionCeiling = c.Int(nullable: false),
                        ReturnRate = c.Single(nullable: false),
                        TenorId = c.String(nullable: false, maxLength: 128),
                        TenorInDays = c.Int(nullable: false),
                        BidOpenDate = c.DateTime(nullable: false),
                        BidCloseDate = c.DateTime(nullable: false),
                        SchemeStartDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        SubscribedUnits = c.Int(nullable: false),
                        UnsubscribedUnits = c.Int(nullable: false),
                        ActualSubscription = c.Double(nullable: false),
                        PaymentPeriodId = c.String(nullable: false, maxLength: 128),
                        PaymentPeriodInDays = c.Int(nullable: false),
                        NoOfUniqueInvestments = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Crop_Id = c.String(maxLength: 128),
                        Tenor_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Scheme_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crops", t => t.Crop_Id)
                .ForeignKey("dbo.Crops", t => t.CropId)
                .ForeignKey("dbo.PaymentPeriods", t => t.PaymentPeriodId)
                .ForeignKey("dbo.Tenors", t => t.Tenor_Id)
                .ForeignKey("dbo.Tenors", t => t.TenorId)
                .Index(t => t.CropId)
                .Index(t => t.TenorId)
                .Index(t => t.PaymentPeriodId)
                .Index(t => t.Crop_Id)
                .Index(t => t.Tenor_Id);
            
            CreateTable(
                "dbo.Crops",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Crop_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchemePaymentDates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SchemeId = c.String(nullable: false, maxLength: 128),
                        PaymentDate = c.DateTime(nullable: false),
                        IsPast = c.Boolean(nullable: false),
                        ExpectedTotalPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualTotalPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Scheme_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SchemePaymentDate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schemes", t => t.SchemeId)
                .ForeignKey("dbo.Schemes", t => t.Scheme_Id)
                .Index(t => t.SchemeId)
                .Index(t => t.Scheme_Id);
            
            CreateTable(
                "dbo.Tenors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TenorInDays = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserID = c.Long(nullable: false),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTransactions = c.Int(nullable: false),
                        NoOfCreditTransactions = c.Int(nullable: false),
                        NoOfDebitTransactions = c.Int(nullable: false),
                        DateOfLastTransaction = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Wallet_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.WalletTransactions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WalletID = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        BankTransactionReference = c.String(maxLength: 50),
                        SourceBankSortCode = c.String(maxLength: 20),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountChartId = c.String(nullable: false, maxLength: 128),
                        BankCode = c.String(nullable: false, maxLength: 20),
                        BankName = c.String(nullable: false, maxLength: 50),
                        CreditAccountNumber = c.String(nullable: false, maxLength: 20),
                        IsCreditDebit = c.Boolean(nullable: false),
                        IsExternalGenerated = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Wallet_Id = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WalletTransaction_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountCharts", t => t.AccountChartId)
                .ForeignKey("dbo.Wallets", t => t.WalletID)
                .ForeignKey("dbo.Wallets", t => t.Wallet_Id)
                .Index(t => t.WalletID)
                .Index(t => t.AccountChartId)
                .Index(t => t.Wallet_Id);
            
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id");
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.WalletTransactions", "Wallet_Id", "dbo.Wallets");
            DropForeignKey("dbo.WalletTransactions", "WalletID", "dbo.Wallets");
            DropForeignKey("dbo.WalletTransactions", "AccountChartId", "dbo.AccountCharts");
            DropForeignKey("dbo.Wallets", "UserID", "dbo.AbpUsers");
            DropForeignKey("dbo.Payments", "AccountChart_Id", "dbo.AccountCharts");
            DropForeignKey("dbo.Payments", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Payments", "SchemeId", "dbo.Schemes");
            DropForeignKey("dbo.Payments", "InvestmentID", "dbo.Investments");
            DropForeignKey("dbo.Investments", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Investments", "TenorID", "dbo.Tenors");
            DropForeignKey("dbo.Investments", "SchemeId", "dbo.Schemes");
            DropForeignKey("dbo.Schemes", "TenorId", "dbo.Tenors");
            DropForeignKey("dbo.Schemes", "Tenor_Id", "dbo.Tenors");
            DropForeignKey("dbo.Investments", "Tenor_Id", "dbo.Tenors");
            DropForeignKey("dbo.SchemePaymentDates", "Scheme_Id", "dbo.Schemes");
            DropForeignKey("dbo.SchemePaymentDates", "SchemeId", "dbo.Schemes");
            DropForeignKey("dbo.Payments", "Scheme_Id", "dbo.Schemes");
            DropForeignKey("dbo.Schemes", "PaymentPeriodId", "dbo.PaymentPeriods");
            DropForeignKey("dbo.Investments", "Scheme_Id", "dbo.Schemes");
            DropForeignKey("dbo.Schemes", "CropId", "dbo.Crops");
            DropForeignKey("dbo.Schemes", "Crop_Id", "dbo.Crops");
            DropForeignKey("dbo.Payments", "Investment_Id", "dbo.Investments");
            DropForeignKey("dbo.Investments", "PaymentPeriodID", "dbo.PaymentPeriods");
            DropForeignKey("dbo.Payments", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Payments", "AccountChartId", "dbo.AccountCharts");
            DropForeignKey("dbo.AccountCharts", "BankId", "dbo.Banks");
            DropIndex("dbo.WalletTransactions", new[] { "Wallet_Id" });
            DropIndex("dbo.WalletTransactions", new[] { "AccountChartId" });
            DropIndex("dbo.WalletTransactions", new[] { "WalletID" });
            DropIndex("dbo.Wallets", new[] { "UserID" });
            DropIndex("dbo.SchemePaymentDates", new[] { "Scheme_Id" });
            DropIndex("dbo.SchemePaymentDates", new[] { "SchemeId" });
            DropIndex("dbo.Schemes", new[] { "Tenor_Id" });
            DropIndex("dbo.Schemes", new[] { "Crop_Id" });
            DropIndex("dbo.Schemes", new[] { "PaymentPeriodId" });
            DropIndex("dbo.Schemes", new[] { "TenorId" });
            DropIndex("dbo.Schemes", new[] { "CropId" });
            DropIndex("dbo.Investments", new[] { "Tenor_Id" });
            DropIndex("dbo.Investments", new[] { "Scheme_Id" });
            DropIndex("dbo.Investments", new[] { "PaymentPeriodID" });
            DropIndex("dbo.Investments", new[] { "TenorID" });
            DropIndex("dbo.Investments", new[] { "SchemeId" });
            DropIndex("dbo.Investments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "AccountChart_Id" });
            DropIndex("dbo.Payments", new[] { "Scheme_Id" });
            DropIndex("dbo.Payments", new[] { "Investment_Id" });
            DropIndex("dbo.Payments", new[] { "AccountChartId" });
            DropIndex("dbo.Payments", new[] { "BankId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "SchemeId" });
            DropIndex("dbo.Payments", new[] { "InvestmentID" });
            DropIndex("dbo.AccountCharts", new[] { "BankId" });
            DropTable("dbo.WalletTransactions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WalletTransaction_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Wallets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Wallet_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Tenors",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenor_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SchemePaymentDates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SchemePaymentDate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Crops",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Crop_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Schemes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Scheme_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PaymentPeriods",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PaymentPeriod_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Investments",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Investment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Payments",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Payment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Banks",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Bank_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AccountCharts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AccountChart_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id", cascadeDelete: true);
        }
    }
}
