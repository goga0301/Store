
using Store.Domain.Models.Domain;

namespace Store.Domain.Service.Domain
{
    public interface IMainCategoryService 
    {
        Task<int> AddMainCategory(CreateMainCategoryModel MainCategory);
        void UpdateMainCategory(UpdateMainCategoryModel MainCategory);
        void DeleteMainCategory(int Id);
        Task<MainCategoryModel> GetMainCategoryByIdAsync(int Id);
        Task<IEnumerable<MainCategoryModel>> GetAllMainCategories();

    }
}
