using ApiMock.AutoMapper.Profiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMock.AutoMapper
{
    public static class BootstraperAutoMapper
    {
        public static Action<IMapperConfigurationExpression> ConfigAction = new Action<IMapperConfigurationExpression>(
cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;


    cfg.AddProfile<Tabela>();

});
    }
}
