namespace hexagonTabela.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Adiconioar(T entity);
        Task Atualizar(T entity);
        Task<T> ObterPorId(Guid Id);
        Task<List<T>> ObterTodos<T>(int pagina, int tamanhoPagina) where T : class;
        Task Remover(T entity);
    }
}
