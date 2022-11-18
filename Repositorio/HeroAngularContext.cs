using Dominio.HeroMicroservice.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraMiggration
{
    public class HeroAngularContext : IdentityDbContext
    {
        public HeroAngularContext(DbContextOptions<HeroAngularContext> options) : base(options)
        {

        }

        public DbSet<Hero> Hero { get; set; }
    }
}
