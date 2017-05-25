using System;
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
using PayStack.Net;
using System.Configuration;
using Pannexus.PsNutrac.Users;
using Abp.UI;

namespace Pannexus.PsNutrac.Investments
{
    public class InvestmentAppService : SampleLTEAppServiceBase, IInvestmentAppService
    {
        private readonly IRepository<Investment, string> _investmentRepo;
        private readonly IRepository<Scheme, string> _schemeRepo;
        private readonly IInvestmentPolicy _investmentPolicy;
        private static PayStackApi _api;

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

        public async Task InstantPayCreateAsync(CreateInvestmentInput input)
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

            //Paystack
            
            var user = await UserManager.GetUserByIdAsync(AbpSession.UserId.Value);
            var response = InitializeRequest_Setup(int.Parse(investment.InvestmentAmount.ToString()), user);
            
            if(response)
            {
                scheme.Investments.Add(investment);
                //await _investmentRepo.InsertAsync(investment);

                //update scheme
                scheme.SubscribedUnits = scheme.SubscribedUnits + 1;
                scheme.NoOfUniqueInvestments = scheme.NoOfUniqueInvestments + 1;
                await _schemeRepo.UpdateAsync(scheme);
            }
            else
            {
                throw new UserFriendlyException("Something went wrong with the payment.");
            }
            
        }

        private bool InitializeRequest_Setup(int amount, User user)
        {
            _api = new PayStackApi(ConfigurationManager.AppSettings["PayStackSecret"]);

            var request = new TransactionInitializeRequest
            {
                AmountInKobo = amount,
                Email = user.EmailAddress,
                Reference = Guid.NewGuid().ToString()
            };

            request.CustomFields.Add(CustomField.From("Name", "name", user.FullName));

            var response = _api.Transactions.Initialize(request);

            return response.Status;
        }
    }
}
