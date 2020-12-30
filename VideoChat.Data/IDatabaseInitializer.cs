using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VideoChat.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
