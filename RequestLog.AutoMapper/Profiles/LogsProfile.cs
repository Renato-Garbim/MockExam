using RequestLog.Entities;
using RequestLog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.AutoMapper.Profiles
{
    public class LogsProfile : global::AutoMapper.Profile
    {
        public LogsProfile()
        {
            CreateMap<HeroLog, HeroLogDTO>().ReverseMap();
        }
    }
}
