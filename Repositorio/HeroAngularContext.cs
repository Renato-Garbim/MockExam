using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MockApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public class HeroAngularContext : IdentityDbContext
    {
        public HeroAngularContext(DbContextOptions<HeroAngularContext> options) : base(options)
        {

        }

        public DbSet<Hero> Hero { get; set; }
    }
}
