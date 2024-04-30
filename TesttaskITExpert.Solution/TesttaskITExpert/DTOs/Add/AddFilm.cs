using System.ComponentModel.DataAnnotations;

namespace TesttaskITExpert.DTOs.Add
{
    public class AddFilm
    {
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        public string director { get; set; }
        [Required(ErrorMessage = "Release Date is required.")]
        public DateTime release { get; set; }
    }
}
