using Sigma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodos();
        Task<Usuario> BuscarPorIdAsync(int id);
        Task<bool> Inserir(Usuario entidade);
        Task<bool> EditarUsuarioAsync(Usuario entidade);
        Task<bool> DeletarUsuarioAsync(Usuario entidade);   
    }

}
