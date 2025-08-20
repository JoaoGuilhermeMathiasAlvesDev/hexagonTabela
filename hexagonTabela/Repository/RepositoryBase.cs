using hexagonTabela.Context;
using hexagonTabela.IRepository;
using Microsoft.EntityFrameworkCore;

namespace hexagonTabela.Repository
{
    public class RepositoryBase<T>(HexagonContext _hexagonContext) : IRepositoryBase<T> where T : class
    {
        public async Task Remover(T entity)
        {
            _hexagonContext.Remove(entity);
            await _hexagonContext.SaveChangesAsync();

        }

        public async Task Adiconioar(T entity)
        {
            await _hexagonContext.AddAsync(entity);
            _hexagonContext.SaveChanges();
        }

        public async Task Atualizar(T entity)
        {
            _hexagonContext.Update(entity);
            await _hexagonContext.SaveChangesAsync();

        }

        async Task<T> IRepositoryBase<T>.ObterPorId(Guid Id)
        {
            return await _hexagonContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == Id);

        }

        public async Task<List<T>> ObterTodos<T>(int pagina, int tamanhoPagina) where T : class
        {
            return await _hexagonContext.Set<T>().Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina).ToListAsync();

        }
    }
}
