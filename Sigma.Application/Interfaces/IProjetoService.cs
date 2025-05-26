using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<List<ProjetosDto>> BuscarTodos();
        Task<bool> InserirProjeto(ProjetoNovoDto model);
        Task<bool> EditarProjeto(ProjetoNovoDto model, int id);
        Task<bool> DeletarProjeto(int id);
    }
}
