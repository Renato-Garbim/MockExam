using HerosHandles.Interfaces.SignalR;
using MockApi.Dominio.Entidades;
using Repositorio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class HeroRepository : RepositoryBase<Hero>, IHeroRepository
    {
        public HeroRepository(HeroAngularContext db, INotifyService ns) : base (db, ns)
        {

        }
    }
}
