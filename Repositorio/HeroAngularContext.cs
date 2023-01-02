using Dominio.HeroMicroservice.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfraMiggration
{
    public class HeroAngularContext : DbContext
    {
        public HeroAngularContext(DbContextOptions<HeroAngularContext> options) : base(options)
        {

        }

        public DbSet<Hero> Hero { get; set; }


        //Rollback for cases where i dont use SQL DB                
        public void Rollback()
        {

            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                switch (x.State)
                {
                    case EntityState.Modified:
                        x.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        x.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        x.Reload();
                        break;
                    default: break;
                }

            });
        }
        

    }
}
