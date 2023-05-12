using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.Products
{
    public class GetProductQuery : IRequest<IApiResponse<ProductModel>>
    {
        public int Id { get; set; }
        public GetProductQuery(int id)
        {
            Id = id;
            
        }
    }
}
