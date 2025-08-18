using hexagonTabela.Entity;
using hexagonTabela.Entity.Enum;

namespace hexagonTabela.Models
{
    public class AdicionarResgistroModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int EstadoCivil { get; set; }
        public string Cpf { get; set; }
        public string Cidade { get; set; }
        public int Estado { get; set; }

    }
}
