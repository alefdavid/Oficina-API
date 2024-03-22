using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Infrastructure.Profiles
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PessoaProfile());
                cfg.AddProfile(new PecaProfile());
            });

            return config.CreateMapper();
        }
    } 
}
