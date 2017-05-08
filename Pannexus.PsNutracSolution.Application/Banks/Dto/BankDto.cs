using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks.Dto
{
    [AutoMapFrom(typeof(Bank))]
    public class BankDto : FullAuditedEntityDto<string>
    {
        public String BankCode { get; set; }

        public String BankName { get; set; }
    }
}
