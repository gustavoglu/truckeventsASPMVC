using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.AutoMap
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(x => x.AddProfile<ProfileAutoMapper>());
        }
    }
}