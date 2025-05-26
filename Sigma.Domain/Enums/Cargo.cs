using System.ComponentModel.DataAnnotations;


namespace Sigma.Domain.Enums
{
    public enum Cargo
    {
        [Display(Name = "Cliente")]
        Cliente = 1,

        [Display(Name = "Administrador")]
        Administrador = 2
    }
}
