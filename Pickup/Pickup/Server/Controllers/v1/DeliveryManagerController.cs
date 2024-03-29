﻿using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.DeliveryRpt.Queries.GetAllPaged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1
{
    public class DeliveryManagerController :BaseApiController<DeliveryManagerController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString,DateTime? From , DateTime? To,string Branch , string Driver , int? CID,[FromQuery] int?[] Status , string sender_from_driver)
        {
            var Rpt = await _mediator.Send(new GetAllRPTPagedQuery(pageNumber, pageSize, searchString , From,To,Branch,Driver,CID, Status, sender_from_driver));
            return Ok(Rpt);
        }
    }
}
