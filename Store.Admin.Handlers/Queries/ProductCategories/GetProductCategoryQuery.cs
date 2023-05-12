using MediatR;
using Store.Domain.Models.Domain;
using Store.Shared.Helpers;

namespace Store.Admin.Handlers.Queries.ProductCategories
{
    public class GetProductCategoryQuery : IRequest<IApiResponse<ProductCategoryModel>>
    {
        public int Id { get; set; }
        public GetProductCategoryQuery(int id)
        {
            Id = id;
            
        }
    }
}
