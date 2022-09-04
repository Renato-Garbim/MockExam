using AutoMapper;
using HeroMicroservice.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMicroservice.AutoMapper
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
