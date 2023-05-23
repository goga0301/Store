using Store.Domain.Entities.Enums;

namespace Store.Domain.Models.Domain
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateProductModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
    }

    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
    }

    public class DeleteProductModel
    {
        public int Id { get; set; }
    }


}
