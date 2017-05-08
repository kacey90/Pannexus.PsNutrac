using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pannexus.PsNutrac.Schemes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Tenors.Dto
{
    [AutoMapFrom(typeof(Tenor))]
    public class TenorDto : FullAuditedEntityDto<string>
    {
        public String TenorInDays { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SchemeDto> Schemes { get; set; }
        //public ICollection<InvestmentDto> Investments { get; set; }
    }
}
