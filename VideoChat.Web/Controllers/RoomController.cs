using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoChat.Core.Requests;

namespace VideoChat.Web.Controllers
{
    [Route("api")]
    public class RoomController : Controller
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateRoom")]
        public async Task<string> CreateRoomAsync()
        {
            return await _mediator.Send(new CreateRoom());
        }
    }
}
