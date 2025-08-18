namespace hexagonTabela.Serveces
{
    public interface IDicionarioServices
    {
        Task<Dictionary<int, string>> ObterEstadosComoDicionario();

        Task<Dictionary<int, string>> ObterEstadoCivilDicionairo();
    }
}
