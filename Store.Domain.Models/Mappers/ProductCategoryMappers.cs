using Store.Domain.Entities;
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
                Description = source.Description,
                MainCategoryId = source.MainCategoryId,
                RecordStatus = source.RecordStatus,
                CreateDate = source.CreateDate,
                CreateUserId = source.CreateUserId
            };
        }
    }
}
