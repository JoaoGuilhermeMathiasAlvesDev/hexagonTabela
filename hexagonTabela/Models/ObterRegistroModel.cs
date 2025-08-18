namespace hexagonTabela.Models
{
    public class ObterRegistroModel
    {
        public Guid Id{ get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int EstadoCivil { get; set; }
        public string Cpf { get; set; }
        public string Cidade { get; set; }
        public int Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
