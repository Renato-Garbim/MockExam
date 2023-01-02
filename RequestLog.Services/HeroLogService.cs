using AutoMapper;
using Domain.Utilities.Framework;
using Repository.Utilities.Framework.Interfaces;
using RequestLog.Entities;
using RequestLog.Services.Interfaces;
using RequestLog.Services.Models;
using RequestLogInfra.Interfaces;

namespace RequestLog.Services
{
    public class HeroLogService : ServiceBase<HeroLog, HeroLogDTO>, IHeroLogService
    {
        private readonly IHeroLogRepository _repository;

        public HeroLogService(IHeroLogRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}