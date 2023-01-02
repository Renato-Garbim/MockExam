using AutoMapper;
using RequestLog.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.AutoMapper
{
    public class BootstraperAutoMapper
    {
        public static Action<IMapperConfigurationExpression> ConfigAction = new Action<IMapperConfigurationExpression>(
cfg =>
{
cfg.AllowNullCollections = true;
cfg.AllowNullDestinationValues = true;


cfg.AddProfile<LogsProfile>();

});
    }
}
