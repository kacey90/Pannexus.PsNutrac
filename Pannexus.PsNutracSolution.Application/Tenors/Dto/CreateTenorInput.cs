using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Tenors.Dto
{
    public class CreateTenorInput
    {
        [Required, MaxLength(50)]
        public String TenorInDays { get; set; }
        public bool IsActive { get; set; }
    }
}
