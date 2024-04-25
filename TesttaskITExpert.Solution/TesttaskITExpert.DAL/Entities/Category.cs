namespace TesttaskITExpert.DAL.Entities
{
    public class Category: BaseEntity
    {
        public string name { get; set; }
        public int? parent_category_id { get; set; }
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category>? SubCategories { get; set; }
        public virtual ICollection<FilmCategory>? FilmCategories { get; set; }
    }
}
