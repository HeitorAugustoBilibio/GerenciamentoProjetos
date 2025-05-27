using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Dtos
{
    public class RetornoLoginDTo
    {
        public class LoginRetornoDTO
        {
            public string Token { get; set; }
            public DateTime Expiracao { get; set; }
        }
    }
}
