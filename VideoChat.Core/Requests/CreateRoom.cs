using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoChat.Core.Requests
{
    public class CreateRoom : IRequest<string>
    {
    }
}
