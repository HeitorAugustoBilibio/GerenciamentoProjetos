using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;

namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;

        private async Task<Projeto> BuscarPorIdOuRetornaErro(int id)
        {
            var projeto = await _projetoRepository.BuscarPorIdAsync(id);

            if (projeto == null)
            {
                throw new KeyNotFoundException($"Projeto com ID {id} não encontrado.");
            }

            return projeto;
        }

        private bool ValidarProjeto(Projeto projeto)
        {
            return projeto.Status.ToString() != "Iniciado"
                || projeto.Status.ToString() != "Planejado"
                || projeto.Status.ToString() != "EmAndamento"
                || projeto.Status.ToString() != "Encerrado";
        }

        private void AtualizarProjetoComDto(Projeto projeto, ProjetoNovoDto dto)
        {
            projeto.Nome = dto.Nome;
            projeto.Descricao = dto.Descricao;
            projeto.DataInicio = dto.DataInicio;
            projeto.PrevTermino = dto.PrevTermino;
            projeto.DataTermino = dto.DataTermino;
            projeto.OrcamentoTotal = dto.OrcamentoTotal;
            projeto.Risco = dto.Risco;
            projeto.Status = dto.Status;
        }

        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
        }
        public async Task<bool> InserirProjeto(ProjetoNovoDto model)
        {
            return await _projetoRepository.Inserir(_mapper.Map<Projeto>(model));
        }
        public async Task<List<ProjetosDto>> BuscarTodos()
        {
            var projetos = await _projetoRepository.BuscarTodos() ?? new List<Projeto>(); ;
            return _mapper.Map<List<ProjetosDto>>(projetos);
        }
        public async Task<bool> EditarProjeto(ProjetoNovoDto model, int id)
        {
            var projeto = await BuscarPorIdOuRetornaErro(id);
            AtualizarProjetoComDto(projeto, model);
            return await _projetoRepository.EditarClienteAsync(_mapper.Map<Projeto>(projeto));
        }
        public async Task<bool> DeletarProjeto(int id)
        {
            var projeto = await BuscarPorIdOuRetornaErro(id);
            var projetoValido = ValidarProjeto(projeto);
            if (!projetoValido)
            {
                return false;
            }
           return await _projetoRepository.DeletarProjetoAsync(projeto);
        }
    }
}
