namespace TesttaskITExpert.BLL.Models.UpdateModels
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int? parent_category_id { get; set; }
    }
}
