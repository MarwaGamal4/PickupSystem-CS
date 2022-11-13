using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.Customers.Commands.AddEdit;
using Pickup.Application.Features.Customers.Commands.AddTransaction;
using Pickup.Application.Features.Customers.Commands.RenewPlan;
using Pickup.Application.Features.Customers.Queries.GetById;
using Pickup.Application.Features.Customers.Queries.GetTimeLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1
{
    public class CustomerController : BaseApiController<CustomerController>
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("GetCustmer")]
        public async Task<IActionResult> GetById(GetCutomerByIdQuery id)
        {
            var Customer = await _mediator.Send(new GetCutomerByIdQuery() { CustomerID = id.CustomerID, CustomerPhone = id.CustomerPhone, CustomerPlanID = id.CustomerPlanID });
            return Ok(Customer);
        }

        [HttpPost("AddSubscription")]
        public async Task<IActionResult> Post(AddSubscriptionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("RenewPickup")]
        public async Task<IActionResult> Renew(RenewPlanCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> Trans(AddTransactionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("GetTransaction")]
        public async Task<IActionResult> GetTransaction(GetCustomerTransactionsQuery command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("GetTotalTransaction")]
        public async Task<IActionResult> GetTotalTransaction(GetTransactionTotalsQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("GetInvoices")]
        public async Task<IActionResult> GetInvoices(GetCustomerInvoicesCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("GetTimeline")]
        public async Task<IActionResult> GetTimeline(GetTimeLineQuery command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
