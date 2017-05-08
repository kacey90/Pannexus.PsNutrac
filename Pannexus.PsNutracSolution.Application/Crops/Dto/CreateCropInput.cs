using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Crops.Dto
{
    public class CreateCropInput
    {
        [MaxLength(3), Required]
        public String Code { get; set; }

        [MaxLength(20), Required]
        public String Name { get; set; }

        [MaxLength(150)]
        public String Description { get; set; }
    }
}
