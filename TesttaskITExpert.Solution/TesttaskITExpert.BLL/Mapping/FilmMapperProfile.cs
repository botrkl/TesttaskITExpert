using AutoMapper;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.BLL.Mapping
{
    public class FilmMapperProfile:Profile
    {
        public FilmMapperProfile()
        {
            CreateMap<AddFilmModel, Film>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.director, opt => opt.MapFrom(src => src.director))
                .ForMember(dest => dest.release, opt => opt.MapFrom(src => src.release));

            CreateMap<UpdateFilmModel, Film>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
               .ForMember(dest => dest.director, opt => opt.MapFrom(src => src.director))
               .ForMember(dest => dest.release, opt => opt.MapFrom(src => src.release));

            CreateMap<Film, FilmModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.director, opt => opt.MapFrom(src => src.director))
                .ForMember(dest => dest.release, opt => opt.MapFrom(src => src.release));
               /* .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.FilmCategories))*/

            CreateMap<FilmModel, Film>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.director, opt => opt.MapFrom(src => src.director))
                .ForMember(dest => dest.release, opt => opt.MapFrom(src => src.release));
                //.ForMember(dest => dest.FilmCategories, opt => opt.MapFrom(src => src.Categories));
        }   
    }
}
