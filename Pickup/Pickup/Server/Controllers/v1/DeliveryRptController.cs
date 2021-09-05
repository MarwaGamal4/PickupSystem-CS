using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.DeliveryRpt.Queries.GetAll;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1
{
    public class DeliveryRptController : BaseApiController<BranchesController>
    {

        [HttpGet("branch/{branchName}")]
        [SwaggerOperation(Tags = new[] { "BranchName" })]
        public async Task<IActionResult> GetByBranchName(string branchName)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { BranchName = branchName });
            return Ok(rpt);
        }

        [HttpGet("branch/{branchName}/{date}")]
        [SwaggerOperation(Tags = new[] { "BranchName" })]
        public async Task<IActionResult> GetByBranchName(string branchName , DateTime date)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { BranchName = branchName,date=date });
            return Ok(rpt);
        }

        [HttpGet("branch/{branchName}/{dateFrom}/{dateTo}")]
        [SwaggerOperation(Tags = new[] { "BranchName" })]
        public async Task<IActionResult> GetByBranchName(string branchName,  DateTime dateFrom ,DateTime dateTo)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { BranchName = branchName, dateFrom = dateFrom , dateTo= dateTo });
            return Ok(rpt);
        }

        [HttpGet("Driver/{DriverhName}")]
        public async Task<IActionResult> GetByDriverhName(string DriverhName)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { DriverName = DriverhName });
            return Ok(rpt);
        }
        [HttpGet("Driver/{DriverhName}/{date}")]
        public async Task<IActionResult> GetByDriverhName(string DriverhName ,  DateTime date)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { DriverName = DriverhName, date = date });
            return Ok(rpt);
        }
        [HttpGet("Driver/{DriverhName}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetByDriverhName(string DriverhName, DateTime dateFrom,  DateTime dateTo)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { DriverName = DriverhName, dateFrom = dateFrom, dateTo = dateTo });
            return Ok(rpt);
        }

        [HttpGet("CID/{cid}")]
        public async Task<IActionResult> GetByCid(int cid)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CID = cid });
            return Ok(rpt);
        }

        [HttpGet("CID/{cid}/{date}")]
        public async Task<IActionResult> GetByCid(int cid,  DateTime date)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CID = cid,date = date });
            return Ok(rpt);
        }
        [HttpGet("CID/{cid}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetByCid(int cid  , DateTime dateFrom,  DateTime dateTo)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CID = cid, dateFrom = dateFrom, dateTo = dateTo });
            return Ok(rpt);
        }

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetByphone(string phone)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CustomerPhone = phone });
            return Ok(rpt);
        }
        [HttpGet("phone/{phone}/{date}")]
        public async Task<IActionResult> GetByphone(string phone ,  DateTime date)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CustomerPhone = phone, date = date });
            return Ok(rpt);
        }
        [HttpGet("phone/{phone}/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetByphone(string phone, DateTime dateFrom, DateTime dateTo)
        {
            var rpt = await _mediator.Send(new GetAllDeliveryRptQuery() { CustomerPhone = phone, dateFrom = dateFrom, dateTo = dateTo });
            return Ok(rpt);
        }
    }
}
