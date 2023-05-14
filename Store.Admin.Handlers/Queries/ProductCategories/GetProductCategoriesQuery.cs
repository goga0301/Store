using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.ProductCategories
{
    public class GetProductCategoriesQuery : IRequest<IApiResponse<IEnumerable<ProductCategoryModel>>>
    {
        
    }
}
