using hexagonTabela.Models;

namespace hexagonTabela.Serveces
{
    public interface IRegistroServices
    {
        Task Adicionar(AdicionarResgistroModel model);
        Task Atualizar (RegistroModel model);
        Task<List<ObterRegistroModel>> ObterTodos(int pagina, int tamanhoPagina);
        Task<ObterRegistroModel> ObterPorId(Guid Id);
        Task Remover (Guid id);
    }
}
