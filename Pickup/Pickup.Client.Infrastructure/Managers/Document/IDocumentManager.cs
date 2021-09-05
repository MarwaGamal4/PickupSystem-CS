using Pickup.Application.Features.Documents.Commands.AddEdit;
using Pickup.Application.Features.Documents.Queries.GetAll;
using Pickup.Application.Requests.Documents;
using Pickup.Shared.Wrapper;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}