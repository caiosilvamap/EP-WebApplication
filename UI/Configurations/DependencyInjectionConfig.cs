using App;
using App.Interfaces;
using Domain.Interfaces;
using Infra.Data;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace UI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection InjectionDependency(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            services.AddScoped<IUsuarioRepository, UsuarioRepositrory>();
            services.AddScoped<IGerenciaRepository, GerenciaRepository>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<IFinanciamentoRepository, FinanciamentoRepository>();
            services.AddScoped<IGerenciaGeralRepository, GerenciaGeralRepository>();
            services.AddScoped<IGerenciaRepository, GerenciaRepository>();
            services.AddScoped<IObjetivoRepository, ObjetivoRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ITemaRepository, TemaRepository>();
            services.AddScoped<IUsuarioProjetoRepository, UsuarioProjetoRespository>();
            services.AddScoped<ITipoFuncaoRepository, TipoFuncaoRepository>();
            services.AddScoped<ITipoCargoRepository, TipoCargoRepository>();

            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IArquivoApp, ArquivoApp>();
            services.AddScoped<IFinanciamentoApp, FinanciamentoApp>();
            services.AddScoped<IGerenciaApp, GerenciaApp>();
            services.AddScoped<IGerenciaGeralApp, GerenciaGeralApp>();
            services.AddScoped<IObjetivoApp, ObjetivoApp>();
            services.AddScoped<IProjetoApp, ProjetoApp>();
            services.AddScoped<ITemaApp, TemaApp>();
            services.AddScoped<ITipoCargoApp, TipoCargoApp>();
            services.AddScoped<IUsuarioProjetoApp, UsuarioProjetoApp>();

            return services; 
        }
    }
}
