using hexagonTabela.Context;
using hexagonTabela.IRepository;
using Microsoft.EntityFrameworkCore;

namespace hexagonTabela.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly HexagonContext _hexagonContext;
        public RepositoryBase(HexagonContext hexagonContext)
        {
            _hexagonContext = hexagonContext;
        }

        public async Task Remover(T entity)
        {
            _hexagonContext.Remove(entity);
            await _hexagonContext.SaveChangesAsync();
            
        }

        async Task<T> IRepositoryBase<T>.Adiconioar(T entity)
        {
            await _hexagonContext.AddAsync(entity);
            _hexagonContext.SaveChanges();
            return entity;
        }

        async Task<T> IRepositoryBase<T>.Atualizar(T entity)
        {
            _hexagonContext.Update(entity);
            _hexagonContext.SaveChanges();
            return entity;
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
