using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using Store.Domain.Models.Domain;

namespace Store.Domain.Models.Mappers
{
    public static class MainCategoryMappers
    {
        public static MainCategoryModel Map(this MainCategory mainCategory)
            => new MainCategoryModel
            {
                Id = mainCategory.Id,
                Name = mainCategory.Name,
                Description = mainCategory.Description ?? "",
                ProductCategories = mainCategory.ProductCategories?.Select(x => x.Map()),
                RecordStatus = mainCategory.RecordStatus,
                CreateDate = mainCategory.CreateDate,
                CreateUserId = mainCategory.CreateUserId
            };

        public static MainCategory Map(this CreateMainCategoryModel mainCategory)
            => new MainCategory
            {
                Name = mainCategory.Name,
                Description = mainCategory.Description ?? "",
                RecordStatus = RecordStatusEnum.Active,
                CreateDate = DateTimeOffset.Now,
                CreateUserId = "test"
            };
    }
}
