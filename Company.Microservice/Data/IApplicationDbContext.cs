using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Company> Companies{ get; set; }
        Task<int> SaveChanges();
    }
}
