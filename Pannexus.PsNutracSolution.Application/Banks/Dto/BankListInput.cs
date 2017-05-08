using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pannexus.PsNutrac.Banks.Dto
{
    public class BankListInput : IPagedResultRequest
    {
        public const int DefaultPageSize = 15;

        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Filter { get; set; }

        public BankListInput()
        {
            MaxResultCount = DefaultPageSize;
        }
    }
}
