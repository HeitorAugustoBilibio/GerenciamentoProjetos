﻿using Sigma.Domain.Enums;

namespace Sigma.Domain.Entities
{
    public class Projeto
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrevTermino { get; set; }
        public DateTime? DataTermino { get; set; }
        public decimal OrcamentoTotal { get; set; }
        public Risco Risco { get; set; }
        public StatusProjeto Status { get; set; }
    }
}
