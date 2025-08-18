using hexagonTabela.Models;

namespace hexagonTabela.Serveces
{
    public interface IRegistroServices
    {
        Task Adicionar(AdicionarResgistroModel model);
        Task Atualizar (RegistroModel model);
        Task<List<ObterRegistroModel>> ObterTodos();
        Task<ObterRegistroModel> ObterPorId(Guid Id);
        Task Remover (RegistroModel model);
    }
}
