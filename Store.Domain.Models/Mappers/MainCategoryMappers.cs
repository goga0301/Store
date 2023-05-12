using Store.Domain.Entities;
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
                RecordStatus = mainCategory.RecordStatus,
                CreateDate = mainCategory.CreateDate,
                CreateUserId = mainCategory.CreateUserId
            };
    }
}
