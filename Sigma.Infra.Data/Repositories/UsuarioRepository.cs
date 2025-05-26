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

        public async Task<List<Usuario>> BuscarTodos()
        {
            return await _dbContext.Usuarios.OrderBy(u => u.Id).ToListAsync();
        }

        public Task<bool> Inserir(Usuario entidade)
        {
            _dbContext.Usuarios.Add(entidade);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(true);
        }
    }
}
