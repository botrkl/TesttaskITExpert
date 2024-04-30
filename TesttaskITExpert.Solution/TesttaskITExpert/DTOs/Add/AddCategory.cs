using System.ComponentModel.DataAnnotations;

namespace TesttaskITExpert.DTOs.Add
{
    public class AddCategory
    {
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        public int? parent_category_id { get; set; }
    }
}
