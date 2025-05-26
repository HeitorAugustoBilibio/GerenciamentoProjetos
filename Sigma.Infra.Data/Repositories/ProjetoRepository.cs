using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SigmaContext _dbContext;

        public ProjetoRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Inserir(Projeto entidade)
        {
            await _dbContext.Projetos.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Projeto>> BuscarTodos()
        {
            return await _dbContext.Projetos.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Projeto> BuscarPorIdAsync(long id)
        {
            return await _dbContext.Projetos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> EditarClienteAsync(Projeto entidade)
        {
            _dbContext.Projetos.Update(entidade);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletarProjetoAsync(Projeto projeto)
        {
            _dbContext.Projetos.Remove(projeto);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
