using System.Data.Common;
using Abp.Zero.EntityFramework;
using Pannexus.PsNutrac.Authorization.Roles;
using Pannexus.PsNutrac.MultiTenancy;
using Pannexus.PsNutrac.Users;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pannexus.PsNutrac.Accounts;
using Pannexus.PsNutrac.Investments;
using Pannexus.PsNutrac.Payments;
using Pannexus.PsNutrac.Schemes;
using Pannexus.PsNutrac.Banks;
using Pannexus.PsNutrac.Tenors;
using Pannexus.PsNutrac.Crops;

namespace Pannexus.PsNutrac.EntityFramework
{
    public class SampleLTEDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public IDbSet<AccountChart> AccountCharts { get; set; }

        public IDbSet<Bank> Banks { get; set; }

        public IDbSet<Crop> Crops { get; set; }

        public IDbSet<Investment> Investments { get; set; }

        public IDbSet<Payment> Payments { get; set; }

        public IDbSet<PaymentPeriod> PaymentPeriods { get; set; }

        public IDbSet<Scheme> Schemes { get; set; }

        public IDbSet<SchemePaymentDate> SchemePaymentDates { get; set; }

        public IDbSet<Tenor> Tenors { get; set; }

        public IDbSet<Wallet> Wallets { get; set; }

        public IDbSet<WalletTransaction> WalletTransactions { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SampleLTEDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SampleLTEDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SampleLTEDbContext since ABP automatically handles it.
         */
        public SampleLTEDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SampleLTEDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AccountChart>()
                .HasRequired(ac => ac.Bank).WithMany().HasForeignKey(ac => ac.BankId);

            modelBuilder.Entity<Investment>()
                .HasRequired(i => i.User).WithMany().HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Investment>()
                .HasRequired(i => i.Scheme).WithMany().HasForeignKey(i => i.SchemeId);
            modelBuilder.Entity<Investment>()
                .HasRequired(i => i.Tenor).WithMany().HasForeignKey(i => i.TenorID);
            modelBuilder.Entity<Investment>()
                .HasRequired(i => i.PaymentPeriod).WithMany().HasForeignKey(i => i.PaymentPeriodID);

            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Investment).WithMany().HasForeignKey(i => i.InvestmentID);
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Scheme).WithMany().HasForeignKey(p => p.SchemeId);
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.User).WithMany().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Bank).WithMany().HasForeignKey(p => p.BankId);
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.AccountChart).WithMany().HasForeignKey(p => p.AccountChartId);

            modelBuilder.Entity<Scheme>()
                .HasRequired(s => s.Crop).WithMany().HasForeignKey(s => s.CropId);
            modelBuilder.Entity<Scheme>()
                .HasRequired(s => s.PaymentPeriod).WithMany().HasForeignKey(s => s.PaymentPeriodId);
            modelBuilder.Entity<Scheme>()
                .HasRequired(s => s.Tenor).WithMany().HasForeignKey(s => s.TenorId);

            modelBuilder.Entity<SchemePaymentDate>()
                .HasRequired(s => s.Scheme).WithMany().HasForeignKey(s => s.SchemeId);

            modelBuilder.Entity<Wallet>()
                .HasRequired(s => s.User).WithMany().HasForeignKey(s => s.UserID);

            modelBuilder.Entity<WalletTransaction>()
                .HasRequired(s => s.Wallet).WithMany().HasForeignKey(s => s.WalletID);
            modelBuilder.Entity<WalletTransaction>()
                .HasRequired(s => s.AccountChart).WithMany().HasForeignKey(s => s.AccountChartId);
        }
    }
}
