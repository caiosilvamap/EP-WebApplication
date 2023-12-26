
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaCadastroProjeto.Data;
using SistemaCadastroProjeto.Mappers;
using SistemaCadastroProjeto.Repositório;

namespace SistemaCadastroProjeto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddDbContext<DataContext>();
            services.AddScoped<IProjetoRepositorio, ProjetoRepositorio>();
            services.AddScoped<IGerenciaGeralRepositorio, GerenciaGeralRepositorio>();
            services.AddScoped<IObjetivoRepositorio, ObjetivoRepositorio>();
            services.AddScoped<ITemaRepositorio, TemaRepositorio>();
            services.AddScoped<IFinanciamentoRepositorio, FinanciamentoRepositorio>();
            services.AddScoped<IGerenciaRepositorio, GerenciaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
