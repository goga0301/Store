using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class MainCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductCategoryModel>? ProductCategories { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }

    }

    public class CreateMainCategoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateMainCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class DeleteMainCategoryModel
    {
        public int Id { get; set; }
    }
}
