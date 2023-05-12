

using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MainCategoryId { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }

    }

    public class CreateProductCategoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MainCategoryId { get; set; }
    }

    public class UpdateProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MainCategoryId { get; set; }
    }

    public class DeleteProductCategoryModel
    {
        public int Id { get; set; }
    }
}
