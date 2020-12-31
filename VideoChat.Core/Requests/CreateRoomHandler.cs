using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace VideoChat.Core.Requests
{
    public class CreateRoomHandler : IRequestHandler<CreateRoom, string>
    {

        public CreateRoomHandler()
        {
        }

        public async Task<string> Handle(CreateRoom request, CancellationToken cancellationToken)
        {
            return "";
        }
    }
}
