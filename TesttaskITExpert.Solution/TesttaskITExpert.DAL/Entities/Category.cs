namespace TesttaskITExpert.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int? parent_category_id { get; set; }
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
