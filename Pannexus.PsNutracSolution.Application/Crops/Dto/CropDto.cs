using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pannexus.PsNutrac.Schemes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Crops.Dto
{
    [AutoMapFrom(typeof(Crop))]
    public class CropDto : FullAuditedEntityDto<string>
    {
        public String Code { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<SchemeDto> Schemes { get; set; }
    }
}
