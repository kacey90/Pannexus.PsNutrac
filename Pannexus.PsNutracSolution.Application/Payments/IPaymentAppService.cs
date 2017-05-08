using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pannexus.PsNutrac.Payments.PaymentPeriods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task CreatePaymentPeriodAsync(CreatePaymentPeriodInput input);

        Task UpdatePaymentPeriodAsync(UpdatePaymentPeriodInput input);

        Task DeletePaymentPeriodAsync(EntityDto<string> input);

        Task<PaymentPeriodDto> GetPaymentPeriodAsync(EntityDto<string> input);

        Task<ListResultDto<PaymentPeriodDto>> GetAllPaymentPeriodsAsync();
    }
}
