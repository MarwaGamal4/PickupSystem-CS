using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.Plans.Queries.GetAll;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1.Plans
{
    public class PlansController : BaseApiController<PlansController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Plans = await _mediator.Send(new GetAllPlansQuery());
            return Ok(Plans);
        }
    }
}
