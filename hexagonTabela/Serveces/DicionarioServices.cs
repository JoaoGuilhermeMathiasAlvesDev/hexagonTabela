
using hexagonTabela.Entity.Enum;
using System.ComponentModel;
using System.Reflection;

namespace hexagonTabela.Serveces
{
    public class DicionarioServices : IDicionarioServices
    {
        public async Task<Dictionary<int, string>> ObterEstadoCivilDicionairo()
        {
            var estadosCivil = Enum.GetValues(typeof(EstadoCivilEnum))
                .Cast<EstadoCivilEnum>()
                .ToDictionary(

                    estadosCivil => (int)estadosCivil,
                    estadosCivil => ObterDescricao(estadosCivil)
                );

            return estadosCivil;
        }

        public async Task<Dictionary<int, string>> ObterEstadosComoDicionario()
        {
            var estados = Enum.GetValues(typeof(EstadoEnum))
                .Cast<EstadoEnum>()
                .ToDictionary(
                    estados => (int)estados,
                    estados => ObterDescricao(estados)
                );

            return estados;
        }

        private String ObterDescricao(Enum valor)
        {
            var campo = valor.GetType().GetField(valor.ToString());
            var atributo = campo?.GetCustomAttribute<DescriptionAttribute>();
            return atributo?.Description ?? valor.ToString();
        }
    }
}
