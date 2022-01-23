using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.Branches.Commands.AddEdit;
using Pickup.Application.Features.Branches.Commands.AddUserToBranch;
using Pickup.Application.Features.Branches.Commands.Delete;
using Pickup.Application.Features.Branches.Queries.GetAll;
using Pickup.Application.Features.Branches.Queries.GetById;
using Pickup.Application.Features.Branches.Queries.GetByUser;
using Pickup.Application.Features.Users.Commands.AddEditBranchesToUser;
using Pickup.Application.Features.Users.Queries.GetUserBranches;
using Pickup.Application.Interfaces.Services;
using Pickup.Shared.Constants.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.v1
{

    public class BranchesController : BaseApiController<BranchesController>
    {
        private readonly ICurrentUserService _currentUserService;

        public BranchesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [Authorize(Policy = Permissions.Branches.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _mediator.Send(new GetAllBranchesQuery());
            return Ok(branches);
        }

        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetAllByUser()
        {
            var branches = await _mediator.Send(new GetBranchesByUserQuery() { UserID = _currentUserService.UserId });
            return Ok(branches);
        }

        [Authorize(Policy = Permissions.Branches.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(AddEditBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [Authorize(Policy = Permissions.Branches.Create)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var branch = await _mediator.Send(new GetBranchbyIdQuery() { BranchId = id });
            return Ok(branch);
        }

        [Authorize(Policy = Permissions.Branches.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBranchCommand { Id = id }));
        }

        [Authorize(Policy = Permissions.Branches.Create)]
        [HttpPost("AddUsers")]
        public async Task<IActionResult> AddUsers(AddUserToBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize(Policy = Permissions.Users.Edit)]
        [HttpPost("AddBranchsToUser")]
        public async Task<IActionResult> Addbranches(AddEditBranchesToUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [Authorize(Policy = Permissions.Branches.View)]
        [HttpGet("GetUserBranches/{id}")]
        public async Task<IActionResult> GetUserBranches(string id)
        {
            var branches = await _mediator.Send(new GetUserBranchesQuery() { UserId = id });
            return Ok(branches);
        }

    }
}
