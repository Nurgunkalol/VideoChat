using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace VideoChat.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
        }
    }
}
