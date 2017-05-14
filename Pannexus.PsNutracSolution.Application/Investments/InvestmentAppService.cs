﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Investments.Dto;
using Abp.Domain.Repositories;
using Pannexus.PsNutrac.Schemes;
using Abp.AutoMapper;
using Pannexus.PsNutrac.Helper;
using System.Data.Entity;
using Abp.Linq.Extensions;
using Abp.Extensions;

namespace Pannexus.PsNutrac.Investments
{
    public class InvestmentAppService : IInvestmentAppService
    {
        private readonly IRepository<Investment, string> _investmentRepo;
        private readonly IRepository<Scheme, string> _schemeRepo;
        private readonly IInvestmentPolicy _investmentPolicy;

        public InvestmentAppService(IRepository<Investment, string> investmentRepo,
            IRepository<Scheme, string> schemeRepo, IInvestmentPolicy investmentPolicy)
        {
            _investmentRepo = investmentRepo;
            _schemeRepo = schemeRepo;
            _investmentPolicy = investmentPolicy;
        }

        public async Task CreateAsync(CreateInvestmentInput input)
        {
            var scheme = await _schemeRepo.GetAsync(input.SchemeId);
            _investmentPolicy.CheckBiddingAttemptPolicy(scheme);

            
            var investment = input.MapTo<Investment>();
            investment.Id = ClassUtil.GenerateUniqueKey();
            investment.SchemeName = scheme.SchemeName;
            investment.InvestmentAmount = input.InvestmentUnit * scheme.ValuePerUnit;
            investment.InvestmentStartDate = scheme.SchemeStartDate;
            investment.ReturnRate = scheme.ReturnRate;
            investment.TenorID = scheme.TenorId;
            investment.TenorInDays = scheme.TenorInDays;
            investment.PaymentPeriodID = scheme.PaymentPeriodId;
            investment.PaymentPeriodInDays = scheme.PaymentPeriodInDays;

            scheme.Investments.Add(investment);
            //await _investmentRepo.InsertAsync(investment);

            //update scheme
            scheme.SubscribedUnits = scheme.SubscribedUnits + 1;
            scheme.NoOfUniqueInvestments = scheme.NoOfUniqueInvestments + 1;
            await _schemeRepo.UpdateAsync(scheme);
        }

        public async Task DeleteAsync(EntityDto<string> input)
        {
            await _investmentRepo.DeleteAsync(input.Id);
        }

        public PagedResultDto<InvestmentDto> GetAllInvestmentsPaged(InvestmentListInput input)
        {
            var investments = _investmentRepo.GetAll()
                .Include(i => i.Payments)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), i => i.SchemeName.Contains(input.Filter))
                .OrderByDescending(i => i.CreationTime)
                .ToList();

            return new PagedResultDto<InvestmentDto>
            {
                TotalCount = investments.Count,
                Items = investments.MapTo<List<InvestmentDto>>()
            };
        }

        public async Task<InvestmentDto> GetAsync(EntityDto<string> input)
        {
            var investment = await _investmentRepo.GetAll()
                .Include(i => i.Payments)
                .Where(i => i.Id == input.Id)
                .FirstOrDefaultAsync();

            return investment.MapTo<InvestmentDto>();
        }

        public async Task UpdateAsync(UpdateInvestmentInput input)
        {
            var investment = await _investmentRepo.GetAsync(input.Id);
            input.MapTo(investment);
            await _investmentRepo.UpdateAsync(investment);
        }
    }
}
