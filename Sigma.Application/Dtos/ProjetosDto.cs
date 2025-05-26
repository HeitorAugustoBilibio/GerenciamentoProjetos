using Sigma.Domain.Enums;

namespace Sigma.Application.Dtos
{
    public class ProjetosDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrevTermino { get; set; }
        public DateTime? DataTermino { get; set; }
        public decimal OrcamentoTotal { get; set; }
        public string? Risco { get; set; }
        public string? Status { get; set; }
    }
}
