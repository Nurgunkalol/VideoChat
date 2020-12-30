using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VideoChat.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext _dataContext;

        public DatabaseInitializer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
         
        public async Task SeedAsync()
        {
            await _dataContext.Database.MigrateAsync();
        }
    }
}
