using InfraMiggration;
using Repository.HeroMicroservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.HeroMicroservice
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly HeroAngularContext _context;
        public IHeroRepository Hero { get; }

        public UnityOfWork(HeroAngularContext context, IHeroRepository heroRepository)
        {
            _context = context;
            Hero = heroRepository;
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Rollback()
        {
           _context.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
