using Microsoft.EntityFrameworkCore;
using RequestLog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLogInfra
{
    public class RequestLogContext : DbContext
    {
        public RequestLogContext(DbContextOptions<RequestLogContext> options) : base(options)
        {

        }

        public DbSet<HeroLog> HeroLog { get; set; }
    }
}
