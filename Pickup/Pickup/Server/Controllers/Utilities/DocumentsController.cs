﻿using Microsoft.AspNetCore.Mvc;
using Pickup.Application.Features.Documents.Commands.AddEdit;
using Pickup.Application.Features.Documents.Commands.Delete;
using Pickup.Application.Features.Documents.Queries.GetAll;
using System.Threading.Tasks;

namespace Pickup.Server.Controllers.Utilities
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : BaseApiController<DocumentsController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString)
        {
            var docs = await _mediator.Send(new GetAllDocumentsQuery(pageNumber, pageSize, searchString));
            return Ok(docs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddEditDocumentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDocumentCommand { Id = id }));
        }
    }
}