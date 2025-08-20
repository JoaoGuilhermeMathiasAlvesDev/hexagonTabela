namespace hexagonTabela.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task Adiconioar(T entity);
        Task Atualizar(T entity);
        Task<T> ObterPorId(Guid Id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task Remover(T entity);
    }
}
