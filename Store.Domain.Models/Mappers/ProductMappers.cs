using Store.Domain.Entities;
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
    }
}
