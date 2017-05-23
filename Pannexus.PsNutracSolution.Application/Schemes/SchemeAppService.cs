using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Schemes.Dto;
using Abp.AutoMapper;
using Pannexus.PsNutrac.Helper;
using Abp.Domain.Repositories;
using Pannexus.PsNutrac.Tenors;
using System.Data.Entity;
using Abp.Linq.Extensions;
using Abp.Extensions;

namespace Pannexus.PsNutrac.Schemes
{
    public class SchemeAppService : ISchemeAppService
    {
        private readonly IRepository<Scheme, string> _schemeRepo;
        private readonly IRepository<Tenor, string> _tenorRepo;
        private readonly ISchemeCreationPolicy _schemeCreationPolicy;

        public SchemeAppService(IRepository<Scheme, string> schemeRepo,
            IRepository<Tenor, string> tenorRepo, ISchemeCreationPolicy schemeCreationPolicy)
        {
            _schemeRepo = schemeRepo;
            _tenorRepo = tenorRepo;
            _schemeCreationPolicy = schemeCreationPolicy;
        }

        //public async Task CreateAsync(CreateSchemeInput input)
        //{
        //    var tenor = await _tenorRepo.GetAsync(input.TenorId);
        //    if (tenor != null)
        //    {
        //        var scheme = input.MapTo<Scheme>();
        //        scheme.Id = ClassUtil.GenerateUniqueKey();

        //        // Add the scheme payment Days - I got confused as to what to do here in adding the schemePaymentDays
        //        //var noPaymentDays = input.TenorInDays / input.PaymentPeriodInDays;
        //        //for (int i = 0; i < noPaymentDays; i++)
        //        //{
        //        //    scheme.SchemePaymentDays.Add(new SchemePaymentDate
        //        //    {
        //        //        SchemeId = scheme.Id,
        //        //        PaymentDate = scheme.SchemeStartDate.AddDays(noPaymentDays),
        //        //        ExpectedTotalPayment = 0,
        //        //        ActualTotalPayment = 0
        //        //    });
        //        //}
        //        //the above was giving this error: Object reference not set to an instance of an object.
        //        tenor.Schemes.Add(scheme);
        //        await _tenorRepo.UpdateAsync(tenor);
        //    }
        //}

        public async Task CreateAsync(CreateSchemeInput input)
        {
            var scheme = input.MapTo<Scheme>();
            scheme.Id = ClassUtil.GenerateUniqueKey();
            scheme.SchemeStartDate = scheme.SchemeStartDate.AddDays(1);
            scheme.BidCloseDate = scheme.BidCloseDate.AddDays(1);
            scheme.BidOpenDate = scheme.BidOpenDate.AddDays(1);

            _schemeCreationPolicy.CheckSchemeCreationAttemptPolicy(scheme);

            // Add the scheme payment Days - I got confused as to what to do here in adding the schemePaymentDays
            var noPaymentDays = input.TenorInDays / input.PaymentPeriodInDays;
            for (int i = 1; i <= noPaymentDays; i++)
            {
                scheme.SchemePaymentDays.Add(new SchemePaymentDate
                {
                    Id = ClassUtil.GenerateUniqueKey(),
                    SchemeId = scheme.Id,
                    PaymentDate = scheme.SchemeStartDate.AddDays(input.PaymentPeriodInDays * i),
                    ExpectedTotalPayment = scheme.SubscriptionCeiling + (scheme.SubscriptionCeiling * decimal.Parse(scheme.ReturnRate.ToString())),
                    ActualTotalPayment = 0
                });
            }
            //the above was giving this error: Object reference not set to an instance of an object.
            await _schemeRepo.InsertAsync(scheme);
        }


        public async Task DeleteAsync(EntityDto<string> input)
        {
            var scheme = await _schemeRepo.GetAsync(input.Id);
            var tenor = await _tenorRepo.GetAsync(scheme.TenorId);
            if (tenor != null)
            {
                tenor.Schemes.Remove(scheme);
                await _tenorRepo.UpdateAsync(tenor);
            }
        }

        public async Task<SchemeDto> GetAsync(EntityDto<string> input)
        {
            var scheme = await _schemeRepo.GetAll()
                .Include(s => s.Investments)
                .Include(s => s.Payments)
                .Where(s => s.Id == input.Id)
                .FirstOrDefaultAsync();

            return scheme.MapTo<SchemeDto>();
        }

        public PagedResultDto<SchemeDto> GetSchemesPagedList(SchemeListInput input)
        {
            var schemes = _schemeRepo.GetAll()
                //.Include(s => s.Investments)
                //.Include(s => s.Payments)
                .WhereIf(!input.Filter.IsNullOrWhiteSpace(), s => s.SchemeCode.Equals(input.Filter) || s.SchemeName.Contains(input.Filter))
                .OrderByDescending(s => s.CreationTime)
                .PageBy(input).ToList();

            return new PagedResultDto<SchemeDto>
            {
                TotalCount = schemes.Count,
                Items = schemes.MapTo<List<SchemeDto>>()
            };
        }

        public async Task UpdateAsync(UpdateSchemeInput input)
        {
            var scheme = await _schemeRepo.GetAsync(input.Id);
            input.MapTo(scheme);
            await _schemeRepo.UpdateAsync(scheme);
        }
    }
}
