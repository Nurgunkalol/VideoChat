using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoChat.EF;

namespace VideoChat.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly string _connectionString;
        private DataContext dataContext;

        public DatabaseFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbContext Get()
        {
            if (dataContext == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseNpgsql(_connectionString);
                dataContext = new DataContext(optionsBuilder.Options);
            }
            return dataContext;
        }

        public void Dispose()
        {
            dataContext?.Dispose();
        }
    }
}
