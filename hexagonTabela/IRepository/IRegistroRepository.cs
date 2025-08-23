using hexagonTabela.Entity;

namespace hexagonTabela.IRepository
{
    public interface IRegistroRepository : IRepositoryBase<Registro>
    {
        Task<List<Registro>> ObterTodos(int pagina, int pageSize);
        Task<Registro> ObterPorCpf(string cpf);
    }
}
