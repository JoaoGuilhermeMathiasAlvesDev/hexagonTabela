using hexagonTabela.Context;
using hexagonTabela.Entity;
using hexagonTabela.IRepository;
using Microsoft.EntityFrameworkCore;

namespace hexagonTabela.Repository
{
    public class RegistroRepository : RepositoryBase<Registro>, IRegistroRepository
    {
        private readonly HexagonContext _hexagonContext;

        public RegistroRepository(HexagonContext hexagonContext) : base(hexagonContext)
        {
            _hexagonContext = hexagonContext;
        }

        public async Task<List<Registro>> ObterTodos(int pagina, int pageSize)
        {
            return await _hexagonContext.Set<Registro>().Skip((pagina - 1) * pageSize)
                .Take(pageSize).ToListAsync();

        }
    }
}
