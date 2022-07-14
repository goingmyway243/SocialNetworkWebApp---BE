using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkWebApp.Cqrs.MessageFeatures.Commands;
using SocialNetworkWebApp.Cqrs.MessageFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly Mediator _mediator;

        public MessageController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllMessagesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetMessageByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMessageCommand request)
        {
            if (request.Id != id)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteMessageCommand { Id = id }));
        }
    }
}
