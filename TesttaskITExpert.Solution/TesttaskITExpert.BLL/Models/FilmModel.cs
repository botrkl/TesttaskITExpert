namespace TesttaskITExpert.BLL.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string director { get; set; }
        public DateTime release { get; set; }
        public virtual IList<CategoryModel>? Categories { get; set; }
    }
}