using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Api.Domain.Models.Request
{
    public class CafeUpdateRequest : CafeRequest
    {
        public int IdCafe { get; set; }
    }
}
