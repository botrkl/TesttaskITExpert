namespace TesttaskITExpert.BLL.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int? parent_category_id { get; set; }
        public virtual CategoryModel? ParentCategory { get; set; }
    }
}
