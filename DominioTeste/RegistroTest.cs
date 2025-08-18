using hexagonTabela.CustomeException;
using hexagonTabela.Entity;
using hexagonTabela.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTeste
{
    public class RegistroTest
    {
        [Theory]
        [InlineData("João Silva", 30, EstadoCivilEnum.Casado, "529.982.247-25", "Rio de Janeiro", EstadoEnum.RJ)]
        [InlineData("Maria Oliveira", 25, EstadoCivilEnum.Solteiro, "12345678909", "São Paulo", EstadoEnum.SP)]
        public void AdiconareAtualizarRegistro_DeveFuncionar_ParaDadosValidos(
        string nome, int idade, EstadoCivilEnum estadoCivil, string cpf, string cidade, EstadoEnum estado)
        {
            var registro = new Registro();

            registro.AdiconareAtualizarRegistro(nome, idade, estadoCivil, cpf, cidade, estado);

            Assert.Equal(nome, registro.Nome);
            Assert.Equal(idade, registro.Idade);
            Assert.Equal(estadoCivil, registro.EstadoCivil);
            Assert.Equal(new string(cpf.Where(char.IsDigit).ToArray()), new string(registro.Cpf.Where(char.IsDigit).ToArray()));
            Assert.Equal(cidade, registro.Cidade);
            Assert.Equal(estado, registro.Estado);
        }

        [Theory]
        [InlineData("João", 30, EstadoCivilEnum.Casado, "111.111.111-11", "Rio", EstadoEnum.RJ)]
        [InlineData("Maria", 25, EstadoCivilEnum.Solteiro, "123", "São Paulo", EstadoEnum.SP)]
        public void AdiconareAtualizarRegistro_DeveLancarExcecao_ParaCpfInvalido(
            string nome, int idade, EstadoCivilEnum estadoCivil, string cpf, string cidade, EstadoEnum estado)
        {
            var registro = new Registro();

            var ex = Assert.Throws<CustomeException>(() =>
                registro.AdiconareAtualizarRegistro(nome, idade, estadoCivil, cpf, cidade, estado));

            Assert.Contains("Esta faltando digitos ou esta com varias numerações iguais no campo CPF, Por favor digite corretamente!", ex.Message);
        }

        [Theory]
        [InlineData("Carlos", 40, EstadoCivilEnum.Viuvo, null, "Curitiba", EstadoEnum.PR)]
        public void AdicionarAtualizar_DeveLancarExecao_QuandoCpfFornulo(
            string nome, int idade, EstadoCivilEnum estadoCivil, string cpf, string cidade, EstadoEnum estado)
        {
            var registro = new Registro();

            var ex = Assert.Throws<CustomeException>(()=>
            registro.AdiconareAtualizarRegistro(nome,idade,estadoCivil,cpf, cidade, estado));

            Assert.Contains("Campo CPF não pode ser vazio ou Nulo.", ex.Message);
        }
    }
}
