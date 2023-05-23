using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class ProductCategoryMappers
    {
        public static ProductCategoryModel Map(this ProductCategory source)
        {
            return new ProductCategoryModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description ?? "",
                MainCategoryId = source.MainCategoryId,
                Products = source.Products?.Select(x => x.Map()),
                RecordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }

        public static ProductCategory Map(this CreateProductCategoryModel source)
        {
            return new ProductCategory
            {
                Name = source.Name,
                Description = source.Description,
                MainCategoryId = source.MainCategoryId,
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };
        }
    }
}
