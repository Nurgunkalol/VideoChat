using Microsoft.EntityFrameworkCore;
using System;
using VideoChat.Entities;

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
