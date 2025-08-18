namespace hexagonTabela.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Adiconioar(T entity);
        void Atualizar<T>(T entity);

        Task<T> ObterPorId(Guid Id);
        Task<IEnumerable<T>> ObterTodosAsync();
       void Remover(Guid id);
    }
}
