using AutoMapper;
using TesttaskITExpert.BLL.Models.AddModels;
using TesttaskITExpert.BLL.Models.UpdateModels;
using TesttaskITExpert.DTOs.Add;
using TesttaskITExpert.DTOs.Update;

namespace TesttaskITExpert.WebMapping
{
    public class CategoryDTOMapperProfile:Profile
    {
        public CategoryDTOMapperProfile()
        {
            CreateMap<AddCategory, AddCategoryModel>();
            CreateMap<UpdateCategory, UpdateCategoryModel>();
        }
    }
}
