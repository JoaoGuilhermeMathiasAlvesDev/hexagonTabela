using hexagonTabela.Entity;
using hexagonTabela.Entity.Enum;
using hexagonTabela.IRepository;
using hexagonTabela.Models;
using Microsoft.AspNetCore.Mvc;

namespace hexagonTabela.Serveces
{
    public class RegistroServices(IRegistroRepository _registroRepository) : IRegistroServices
    {

        public async Task Adicionar(AdicionarResgistroModel model)
        {
            if (model is null)
                throw new ArgumentNullException("Registro não pode ser Nullo ou vazio.");

            var novoRegistro = new Registro();

            novoRegistro.AdiconareRegistro(
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

            var obterAntigoRegistroParaAtualizar = await _registroRepository.ObterPorId(model.Id);


            obterAntigoRegistroParaAtualizar.AtualizarRegistro(model.Nome, model.Idade, model.EstadoCivil, model.Cidade, model.Estado);


            obterAntigoRegistroParaAtualizar.SetDataAtualizacao(obterAntigoRegistroParaAtualizar);

            await _registroRepository.Atualizar(obterAntigoRegistroParaAtualizar);
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

        public async Task<List<ObterRegistroModel>> ObterTodos(int pagina, int tamanhoPagina)
        {
            var registros = await _registroRepository.ObterTodos(pagina, tamanhoPagina);

            if (registros == null || !registros.Any())
                throw new InvalidOperationException("Não existe registro.");

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

        public async Task Remover(Guid id)
        {

            var obterRegistro = await _registroRepository.ObterPorId(id);

            if (obterRegistro == null)
                throw new ArgumentException("Não existe esse registro");


           await _registroRepository.Remover(obterRegistro);
        }
    }
}
