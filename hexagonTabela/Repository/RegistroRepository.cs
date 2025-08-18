using hexagonTabela.Context;
using hexagonTabela.Entity;
using hexagonTabela.IRepository;

namespace hexagonTabela.Repository
{
    public class RegistroRepository : RepositoryBase<Registro>, IRegistroRepository
    {
        public RegistroRepository(HexagonContext hexagonContext) : base(hexagonContext)
        {
        }
    }
}
