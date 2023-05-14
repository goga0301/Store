using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.MainCategories
{
    public class GetMainCategoriesQuery : IRequest<IApiResponse<IEnumerable<MainCategoryModel>>>
    {
    }
}
