using hexagonTabela.Entity;
using hexagonTabela.Entity.Enum;
using hexagonTabela.IRepository;
using hexagonTabela.Models;
using Microsoft.AspNetCore.Mvc;

namespace hexagonTabela.Serveces
{
    public class RegistroServices : IRegistroServices
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroServices(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        public async Task Adicionar(AdicionarResgistroModel model)
        {
            if (model is null)
                throw new ArgumentNullException("Registro não pode ser Nullo ou vazio.");

            var novoRegistro = new Registro();

            novoRegistro.AdiconareAtualizarRegistro(
                                                model.Nome,
                                                model.Idade,
                                                (int)model.EstadoCivil,
                                                model.Cpf,
                                                model.Cidade,
                                                (int)model.Estado);
                                               

            await _registroRepository.Adiconioar(novoRegistro);

        }

        public async Task Atualizar(RegistroModel model)
        {
            if (model is null)
                throw new ArgumentNullException("Registro não pode ser nullo ou vazio.");



            var AtualizarRegistro = new Registro();

            AtualizarRegistro.AdiconareAtualizarRegistro(
                                                        model.Nome,
                                                        model.Idade,
                                                        model.EstadoCivil,
                                                        model.Cpf,
                                                        model.Cidade,
                                                        model.Estado);
                                                      
            AtualizarRegistro.SetDataAtualizacao(AtualizarRegistro);

            _registroRepository.Atualizar(AtualizarRegistro);
        }

        public async Task<ObterRegistroModel> ObterPorId(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentNullException("Por gentilezar digite um id.");

            var registro = await _registroRepository.ObterPorId(Id);

            if (registro == null)
                throw new ArgumentNullException("Registro não encontrado.");

            var resultado = new ObterRegistroModel
            {
                Id = registro.Id,
                Nome = registro.Nome,
                Cpf = registro.Cpf,
                Cidade = registro.Cidade,
                Estado = (int)registro.Estado,
                EstadoCivil = (int)registro.EstadoCivil,
                Idade = registro.Idade,
                DataAtualizacao = registro.DataAtualizacao,
            };

            return resultado;
        }

        public async Task<List<ObterRegistroModel>> ObterTodos()
        {
            var registros = await _registroRepository.ObterTodosAsync();

            if (registros is null)
                throw new ArgumentNullException("Não existe registro.");

            return registros.Select(r => new ObterRegistroModel
            {
                Id = r.Id,
                Nome = r.Nome,
                Cpf = r.Cpf,
                Cidade = r.Cidade,
                Idade = r.Idade,
                Estado = (int)r.Estado,
                EstadoCivil = (int)r.EstadoCivil,
                DataAtualizacao = r.DataAtualizacao,
                DataCadastro = r.DataCadastro,
            }).ToList();
        }

        public async Task Remover(RegistroModel model)
        {

            var verificarExiste = await _registroRepository.ObterPorId(model.Id);
            bool existe = verificarExiste != null ? true : false;

            if (!existe)
                throw new ArgumentException("Não existe esse registro");

            _registroRepository.Remover(model.Id);
        }
    }
}
