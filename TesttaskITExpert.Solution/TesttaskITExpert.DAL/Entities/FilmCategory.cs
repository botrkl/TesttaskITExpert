namespace TesttaskITExpert.DAL.Entities
{
    public class FilmCategory: BaseEntity
    {
        public int film_id { get; set; }
        public int category_id { get; set; }
        public virtual Film film { get; set; }
        public virtual Category category { get; set; }
    }
}
