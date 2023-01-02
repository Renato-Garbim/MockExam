
using Repository.Utilities.Framework;
using RequestLog.Entities;
using RequestLogInfra.Interfaces;


namespace RequestLogInfra.Repositories
{
    public class HeroLogRepository : RepositoryBase<HeroLog>, IHeroLogRepository
    {
        public HeroLogRepository(RequestLogContext db) : base(db)
        {

        }
    }
}
