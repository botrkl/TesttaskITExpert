using System.ComponentModel.DataAnnotations;

namespace TesttaskITExpert.DTOs.Update
{
    public class UpdateCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        public int? parent_category_id { get; set; }
    }
}
