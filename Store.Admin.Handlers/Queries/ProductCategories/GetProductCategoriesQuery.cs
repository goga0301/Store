using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.ProductCategories
{
    public class GetProductCategoriesQuery : IRequest<IApiResponse<IEnumerable<ProductCategoryModel>>>
    {
        
    }
}
