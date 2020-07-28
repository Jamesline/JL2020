using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forecast.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Coge> Coges{ get; set; }
        Task<int> SaveChanges();
    }
}
