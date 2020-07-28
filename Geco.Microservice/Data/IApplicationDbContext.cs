using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geco.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Geco> Gecos{ get; set; }
        Task<int> SaveChanges();
    }
}
