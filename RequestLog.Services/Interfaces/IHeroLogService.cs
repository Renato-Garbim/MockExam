using Domain.Utilities.Framework.Interface;
using RequestLog.Entities;
using RequestLog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.Services.Interfaces
{
    public interface IHeroLogService : IServiceBase<HeroLog, HeroLogDTO>
    {
    }
}
