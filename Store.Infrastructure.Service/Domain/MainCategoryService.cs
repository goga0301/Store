using Store.Domain.Models.Domain;
using Store.Domain.Models.Mappers;
using Store.Domain.Repository;
using Store.Domain.Service.Domain;

namespace Store.Infrastructure.Service.Domain
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public MainCategoryService(IMainCategoryRepository MainCategoryRepository)
        {
            _mainCategoryRepository = MainCategoryRepository;
        }

        public async Task<int> AddMainCategory(CreateMainCategoryModel mainCategory)
        {
            return await _mainCategoryRepository.CreateAsync(mainCategory.Map());
        }

        public async void DeleteMainCategory(int Id)
        {
            var mainCategory = await _mainCategoryRepository.GetSingleAsync(x => x.Id == Id);
            if (mainCategory == null)
            {
                throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");
            }
            _mainCategoryRepository.SoftDelete(mainCategory);
            await _mainCategoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MainCategoryModel>> GetAllMainCategories()
        {
            return (await _mainCategoryRepository.GetAllAsync(i => i.ProductCategories )).Select(x => x.Map());
        }

        public async Task<MainCategoryModel> GetMainCategoryByIdAsync(int id)
        {
            var mainCategory = await _mainCategoryRepository.GetSingleAsync(x => x.Id == id);
            if (mainCategory == null)
            {
                throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");
            }
            return mainCategory.Map();
        }

        public async void UpdateMainCategory(UpdateMainCategoryModel mainCategory)
        {
            var category = await _mainCategoryRepository.GetSingleAsync(x => x.Id == mainCategory.Id, i =>  i.ProductCategories );
            if (category == null)
            {
                throw new Exception("ძირითადი კატეგორია ვერ მოიძებნა");
            }
            category.Name = mainCategory.Name;
            category.Description = mainCategory.Description;

            _mainCategoryRepository.Update(category);
            await _mainCategoryRepository.SaveChangesAsync();
        }
    }
}
