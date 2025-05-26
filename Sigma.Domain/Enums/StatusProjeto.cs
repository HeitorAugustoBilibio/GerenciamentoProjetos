using System.ComponentModel.DataAnnotations;

namespace Sigma.Domain.Enums
{
    public enum StatusProjeto
    {
        [Display(Name = "Em Análise")]
        EmAnalise = 1,

        [Display(Name = "Análise Realizada")]
        AnaliseRealizada = 2,

        [Display(Name = "Análise Aprovada")]
        AnaliseAprovada = 3,

        [Display(Name = "Iniciado")]
        Iniciado = 4,

        [Display(Name = "Planejado")]
        Planejado = 5,

        [Display(Name = "Em Andamento")]
        EmAndamento = 6,

        [Display(Name = "Encerrado")]
        Encerrado = 7,

        [Display(Name = "Cancelado")]
        Cancelado = 8
    }
}