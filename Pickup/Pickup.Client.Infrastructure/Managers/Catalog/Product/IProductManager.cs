using Pickup.Application.Features.Products.Commands.AddEdit;
using Pickup.Application.Features.Products.Queries.GetAllPaged;
using Pickup.Application.Requests.Catalog;
using Pickup.Shared.Wrapper;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<string> ExportToExcelAsync();
    }
}