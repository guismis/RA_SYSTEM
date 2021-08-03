using AutoMapper;
using DevIO.Domain.Models;
using TesteProgramacao.ViewModels;

namespace TesteProgramacao.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Autor, AutorViewModels>().ReverseMap();
            CreateMap<Editora, EditoraViewModels>().ReverseMap();
            CreateMap<Livro, LivroViewModels>().ReverseMap();

        }
    }
}