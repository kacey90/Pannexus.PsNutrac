using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Pannexus.PsNutrac.Helper;
using Pannexus.PsNutrac.Payments.PaymentPeriods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IRepository<PaymentPeriod, string> _paymentPeriodRepo;

        public PaymentAppService(IRepository<PaymentPeriod, string> paymentPeriodRepo)
        {
            _paymentPeriodRepo = paymentPeriodRepo;
        }

        public async Task CreatePaymentPeriodAsync(CreatePaymentPeriodInput input)
        {
            var paymentPeriod = new PaymentPeriod
            {
                Id = ClassUtil.GenerateUniqueKey(),
                PeriodInDays = input.PeriodInDays
            };
            //paymentPeriod.Id = ClassUtil.GenerateUniqueKey();
            await _paymentPeriodRepo.InsertAsync(paymentPeriod);
        }

        public async Task DeletePaymentPeriodAsync(EntityDto<string> input)
        {
            await _paymentPeriodRepo.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<PaymentPeriodDto>> GetAllPaymentPeriodsAsync()
        {
            var paymentPeriods = await _paymentPeriodRepo.GetAllListAsync();

            return new ListResultDto<PaymentPeriodDto>(
                paymentPeriods.MapTo<List<PaymentPeriodDto>>()
                );
        }

        public async Task<PaymentPeriodDto> GetPaymentPeriodAsync(EntityDto<string> input)
        {
            var paymentPeriod = await _paymentPeriodRepo.GetAsync(input.Id);

            return paymentPeriod.MapTo<PaymentPeriodDto>();
        }

        public async Task UpdatePaymentPeriodAsync(UpdatePaymentPeriodInput input)
        {
            var paymentPeriod = await _paymentPeriodRepo.GetAsync(input.Id);
            if (paymentPeriod != null)
            {
                input.MapTo<PaymentPeriodDto>();
            }
        }
    }
}
