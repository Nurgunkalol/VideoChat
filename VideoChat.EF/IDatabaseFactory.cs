using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoChat.EF
{
    public interface IDatabaseFactory : IDisposable
    {
        DbContext Get();
    }
}
