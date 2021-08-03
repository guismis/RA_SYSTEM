
using DevIO.Domain.Data.Context;
using DevIO.Domain.Data.Repository;
using DevIO.Domain.Intefaces;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Notificacoes;
using DevIO.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TesteProgramacao.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CatalogoDbContext>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<ILivroService, LivroServise>();

            return services;
        }
    }
}