using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Products
{
    public class GetProductsQuery : IRequest<IApiResponse<IEnumerable<ProductModel>>>
    {
        
    }
}
