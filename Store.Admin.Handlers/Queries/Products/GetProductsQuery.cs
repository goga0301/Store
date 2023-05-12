using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Products
{
    public class GetProductsQuery : IRequest<IApiResponse<IEnumerable<ProductModel>>>
    {
        
    }
}
