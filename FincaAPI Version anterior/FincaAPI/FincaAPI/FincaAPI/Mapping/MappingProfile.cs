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
            CreateMap<data.Animales, Entidades.Animales>().ReverseMap();
            CreateMap<data.Numeros, Entidades.Numeros>().ReverseMap();
            CreateMap<data.Roles, Entidades.Roles>().ReverseMap();
            CreateMap<data.Generos, Entidades.Generos>().ReverseMap();
            CreateMap<data.EntradaConceptos, Entidades.EntradaConceptos>().ReverseMap();
            CreateMap<data.SalidaConceptos, Entidades.SalidaConceptos>().ReverseMap();
            CreateMap<data.Colores, Entidades.Colores>().ReverseMap();
            CreateMap<data.Usuarios, Entidades.Usuarios>().ReverseMap();
        }
    }
}
