namespace TesttaskITExpert.DAL.Entities
{
    public class Film: BaseEntity
    {
        public string name { get; set; }
        public string director { get; set; }
        public DateTime release { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}