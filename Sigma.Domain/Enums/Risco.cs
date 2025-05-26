using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Enums
{
    public enum Risco
    {
        [Display(Name = "Baixo")]
        Baixa = 1,
        [Display(Name = "Médio")]
        Médio = 2,
        [Display(Name = "Alto")]
        Alto = 3 
    }
}
