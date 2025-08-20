using hexagonTabela.Context;
using hexagonTabela.IRepository;
using Microsoft.EntityFrameworkCore;

namespace hexagonTabela.Repository
{
    public class RepositoryBase<T> (HexagonContext _hexagonContext) : IRepositoryBase<T> where T : class
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

        async Task<IEnumerable<T>> IRepositoryBase<T>.ObterTodosAsync()
        {
            return await _hexagonContext.Set<T>().Take(10).ToListAsync();
        }

    }
}
