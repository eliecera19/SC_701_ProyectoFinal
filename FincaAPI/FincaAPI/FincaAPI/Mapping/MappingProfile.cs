using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Numeros, Entidades.Numeros>().ReverseMap();
            CreateMap<data.Roles, Entidades.Roles>().ReverseMap();
        }
    }
}
