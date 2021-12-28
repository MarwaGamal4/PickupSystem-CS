using Pickup.Application.Features.Plans.Queries.Dto;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.Plans
{
    public interface IPlanManager : IManager
    {
        Task<IResult<List<PlanDtoResponse>>> GetAllAsync();
    }
}
