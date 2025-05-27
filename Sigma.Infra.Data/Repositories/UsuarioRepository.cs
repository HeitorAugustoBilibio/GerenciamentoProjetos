using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SigmaContext _dbContext;

        public UsuarioRepository(SigmaContext context)
        {
            _dbContext = context;
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> BuscarTodos()
        {
            return await _dbContext.Usuarios.OrderBy(u => u.Id).ToListAsync();
        }

        public Task<bool> EditarUsuarioAsync(Usuario entidade)
        {
            _dbContext.Usuarios.Update(entidade);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(true);
        }

        public Task<bool> Inserir(Usuario entidade)
        {
            _dbContext.Usuarios.Add(entidade);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(true);
        }

        public async Task<bool> DeletarUsuarioAsync(Usuario entidade)
        {
            _dbContext.Usuarios.Remove(entidade);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
