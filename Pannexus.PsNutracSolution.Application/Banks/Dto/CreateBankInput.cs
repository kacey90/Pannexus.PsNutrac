using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks.Dto
{
    public class CreateBankInput
    {
        [MaxLength(3), Required]
        public String BankCode { get; set; }

        [MaxLength(50), Required]
        public String BankName { get; set; }
    }
}
