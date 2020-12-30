using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using VideoChat.Core.Entities;

namespace VideoChat.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
        }
    }
}
