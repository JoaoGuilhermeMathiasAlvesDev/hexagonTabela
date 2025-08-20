using hexagonTabela.IRepository;
using hexagonTabela.Repository;
using hexagonTabela.Serveces;
using Microsoft.EntityFrameworkCore.Internal;

namespace hexagonTabela.Configuracao
{
    public static class InjeicaoDeIdenpendencia
    {
        public static void InjeicaoDeIdependenciaConfiguracao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRegistroServices, RegistroServices>();
            services.AddTransient<IDicionarioServices, DicionarioServices>();
            services.AddTransient<IRegistroRepository, RegistroRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
