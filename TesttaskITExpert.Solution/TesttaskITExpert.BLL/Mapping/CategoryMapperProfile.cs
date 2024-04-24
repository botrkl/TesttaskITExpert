using AutoMapper;
using TesttaskITExpert.BLL.Models;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.DAL.Entities;

namespace TesttaskITExpert.BLL.Mapping
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<AddCategoryModel, Category>()
                .ForMember(dest => dest.parent_category_id, opt => opt.MapFrom(src => src.parent_category_id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name));

            CreateMap<UpdateCategoryModel, Category>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
               .ForMember(dest => dest.parent_category_id, opt => opt.MapFrom(src => src.parent_category_id));

            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.parent_category_id, opt => opt.MapFrom(src => src.parent_category_id))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory))
                .ForMember(dest => dest.Films, opt => opt.MapFrom(src => src.FilmCategories));

            CreateMap<CategoryModel, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.parent_category_id, opt => opt.MapFrom(src => src.parent_category_id))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory))
                .ForMember(dest => dest.FilmCategories, opt => opt.MapFrom(src => src.Films));
        }   
    }
}
