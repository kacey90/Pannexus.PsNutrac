using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Investments.Dto
{
    [AutoMapTo(typeof(Investment))]
    public class CreateInvestmentInput
    {
        public long UserId { get; set; }

        [MaxLength(20), Required]
        public String SchemeId { get; set; }

        [MaxLength(50), Required]
        public String SchemeName { get; set; }

        public int InvestmentUnit { get; set; }

        public decimal InvestmentAmount { get; set; } //InvestmentAmount = InvestmentUnit * Scheme.ValuePerUnit

        public DateTime InvestmentDate { get; set; }

        public DateTime InvestmentStartDate { get; set; }

        public decimal ReturnRate { get; set; } // From The Scheme.ReturnRate

        [MaxLength(20), Required]
        public String TenorID { get; set; }

        public int TenorInDays { get; set; }

        [MaxLength(20), Required]
        public String PaymentPeriodID { get; set; }

        public int PaymentPeriodInDays { get; set; }

        //public decimal ExpectedTotalReturn  //InvestmentAmount * returnRate + InvestmentAmount
        //{
        //    get { return InvestmentAmount + InvestmentAmount * ReturnRate; }
        //}

        public double NoOfTotalPayments { get; set; } // how is this deduced

        

        public bool IsActive { get; set; }

        
    }
}
