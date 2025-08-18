using hexagonTabela.Entity.Enum;
using hexagonTabela.Models;
using hexagonTabela.ValidacaoDominio;

namespace hexagonTabela.Entity
{
    
    public class Registro : EntityBase.EntityBase
    {
        public string Nome { get;private set; }
        public int Idade { get;private set; }
        public EstadoCivilEnum EstadoCivil { get;private set; }
        public string Cpf { get;private set; }
        public string Cidade { get; private set; }
        public EstadoEnum Estado { get; private set; }

        public Registro(){ }

        public void AdiconareRegistro(string nome, int idade, int estadoCivil, string cpf, string cidade, int estado)
        {
            Nome = nome;
            Idade = idade;
            EstadoCivil = (EstadoCivilEnum)estadoCivil;
            Cpf = cpf;
            Cidade = cidade;
            Estado = (EstadoEnum)estado;

            Validar();
        }

        public void AtualizarRegistro(string nome, int idade, int estadoCivil, string cidade, int estado)
        {
            Nome = nome;
            Idade = idade;
            EstadoCivil = (EstadoCivilEnum)estadoCivil;
            Cidade = cidade;
            Estado = (EstadoEnum)estado;
        }



        public void SetDataAtualizacao(EntityBase.EntityBase entity) => entity.DataAtualizacao = DateTime.Now;

        public void Validar()
        {
            Validacao.CPFValidacao(Cpf);
        }
    }
}
