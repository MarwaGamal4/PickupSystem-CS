using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.Plans.Queries.GetAll;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1.Plans
{
    public class PlansController : BaseApiController<PlansController>
    {
        [HttpGet("{lang}")]
        public async Task<IActionResult> GetAll(string lang)
        {
            var Plans = await _mediator.Send(new GetAllPlansQuery() { LanguageCode = lang });
            return Ok(Plans);
        }
    }
}
