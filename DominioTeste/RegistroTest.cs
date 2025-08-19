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
        [InlineData("João Silva", 30, 1, "529.982.247-25", "Rio de Janeiro", 33)]
        [InlineData("Maria Oliveira", 25, 2, "12345678909", "São Paulo", 35)]
        public void AdiconareAtualizarRegistro_DeveFuncionar_ParaDadosValidos(
        string nome, int idade, int estadoCivil, string cpf, string cidade, int estado)
        {
            var registro = new Registro();

            registro.AdiconareRegistro(nome, idade, estadoCivil, cpf, cidade, estado);

            Assert.Equal(nome, registro.Nome);
            Assert.Equal(idade, registro.Idade);
            Assert.Equal(estadoCivil,(int) registro.EstadoCivil);
            Assert.Equal(new string(cpf.Where(char.IsDigit).ToArray()), new string(registro.Cpf.Where(char.IsDigit).ToArray()));
            Assert.Equal(cidade, registro.Cidade);
            Assert.Equal(estado,(int) registro.Estado);
        }

        [Theory]
        [InlineData("João", 30, 1, "111.111.111-11", "Rio", 33)]
        [InlineData("Maria", 25, 2, "123", "São Paulo", 35)]
        public void AdiconareAtualizarRegistro_DeveLancarExcecao_ParaCpfInvalido(
            string nome, int idade, int estadoCivil, string cpf, string cidade, int estado)
        {
            var registro = new Registro();

            var ex = Assert.Throws<CustomeException>(() =>
                registro.AdiconareRegistro(nome, idade, estadoCivil, cpf, cidade, estado));

            Assert.Contains("Esta faltando digitos ou esta com varias numerações iguais no campo CPF, Por favor digite corretamente!", ex.Message);
        }

        [Theory]
        [InlineData("Carlos", 40, 3, "Curitiba", 41)]
        public void DeveAtaulizarORegistro(
            string nome, int idade, int estadoCivil,  string cidade, int estado)
        {
            var registro = new Registro();
            registro.AtualizarRegistro(nome,idade,estadoCivil,cidade, estado);

            Assert.Equal(nome, registro.Nome);
            Assert.Equal(idade, registro.Idade);
            Assert.Equal(estadoCivil, (int)registro.EstadoCivil);
            Assert.Equal(cidade, registro.Cidade);
            Assert.Equal(estado, (int)registro.Estado);
        }
    }
}
