using MediatR;
using Store.Domain.Models.Domain;
using Shared.Helpers;

namespace Store.Admin.Handlers.Queries.MainCategories
{
    public class GetMainCategoryQuery : IRequest<IApiResponse<MainCategoryModel>>
    {
        public int Id { get; set; }
        public GetMainCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
