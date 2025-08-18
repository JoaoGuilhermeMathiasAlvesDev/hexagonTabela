namespace hexagonTabela.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Adiconioar(T entity);
        Task<T> Atualizar(T entity);

        Task<T> ObterPorId(Guid Id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task Remover(T entity);
    }
}
