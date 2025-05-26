using Sigma.Domain.Entities;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> BuscarTodos();
        Task<bool> Inserir(Projeto entidade);
        Task<bool> EditarClienteAsync(Projeto entidade);
        Task<Projeto> BuscarPorIdAsync(long id);
        Task<bool> DeletarProjetoAsync(Projeto projeto); 
    }
}
