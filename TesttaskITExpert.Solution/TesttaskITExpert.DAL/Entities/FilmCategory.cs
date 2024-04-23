namespace TesttaskITExpert.DAL.Entities
{
    public class FilmCategory
    {
        public int Id { get; set; }
        public int film_id { get; set; }
        public int category_id { get; set; }
        public virtual Film film { get; set; }
        public virtual Category category { get; set; }
    }
}
