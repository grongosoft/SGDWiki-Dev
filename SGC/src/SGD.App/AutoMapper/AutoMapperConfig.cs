using AutoMapper;
using SGC.Business.Models.Entidades;
using SGD.App.ViewModel;

namespace SGD.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
        }
    }
}