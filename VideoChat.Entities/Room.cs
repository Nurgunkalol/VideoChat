using System;

namespace VideoChat.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string RoomName { get; set; }
        public string Token { get; set; }
        public RoomStatus Status { get; set; }
    }
}
