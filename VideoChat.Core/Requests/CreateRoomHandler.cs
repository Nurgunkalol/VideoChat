using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VideoChat.EF;
using VideoChat.Entities;

namespace VideoChat.Core.Requests
{
    public class CreateRoomHandler : IRequestHandler<CreateRoom, string>
    {
        private readonly IEntityRepository<Room> _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomHandler(IEntityRepository<Room> roomRepository,
            IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CreateRoom request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                RoomName = "TEST",
                Status = RoomStatus.Processing,
                Token = Guid.NewGuid().ToString(),
                SessionId = ""
            };
            _roomRepository.Add(room);
            await _unitOfWork.CommitAsync();
            return room.Token;
        }
    }
}
