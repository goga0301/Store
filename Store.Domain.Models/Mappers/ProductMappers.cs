using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class ProductMappers
    {
        public static ProductModel Map(this Product source)
        {
            return new ProductModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                Stock = source.Stock,
                ImageUrl = source.ImageUrl,
                ProductCategoryId = source.ProductCategoryId,
                RecordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
                
            };
        }

        public static Product MapForCreate(this CreateProductModel source)
        {
            return new Product
            {
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                Stock = source.Stock,
                ImageUrl = source.ImageUrl,
                ProductCategoryId = source.ProductCategoryId,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };
        }

        
    }
}
