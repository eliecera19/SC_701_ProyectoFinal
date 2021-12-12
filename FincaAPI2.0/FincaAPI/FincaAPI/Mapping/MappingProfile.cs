using AutoMapper;
using FincaAPI.DO.Objects;
using FincaAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animales, AnimalesDTO>().ReverseMap();
            CreateMap<Animales, AnimalesDTOPost>().ReverseMap();
            CreateMap<Animales, AnimalesDTOPut>().ReverseMap();
            CreateMap<Colores, ColoresDTO>().ReverseMap();
            CreateMap<Colores, ColoresDTOPost>().ReverseMap();
            CreateMap<EntradaConceptos, EntradaConceptosDTO>().ReverseMap();
            CreateMap<Generos, GenerosDTO>().ReverseMap();
            CreateMap<Numeros, NumerosDTO>().ReverseMap();
            CreateMap<Numeros, NumerosDTOPost>().ReverseMap();
            CreateMap<SalidaConceptos, SalidaConceptosDTO>().ReverseMap();
            CreateMap<SalidaConceptos, SalidaConceptosDTOPost>().ReverseMap();
            CreateMap<Usuarios, UsuariosDTO>().ReverseMap();
            CreateMap<Usuarios, UsuarioDTOCreacion>().ReverseMap();
            CreateMap<Roles, RolesDTO>().ReverseMap();
            CreateMap<Roles, RolesDTOPost>().ReverseMap();
            CreateMap<Bitacora, BitacoraDTO>().ReverseMap();
            CreateMap<EntradaConceptos, EntradaConceptosDTO>().ReverseMap();
            CreateMap<EntradaConceptos, EntradaConceptosDTOPost>().ReverseMap();
        }
    }
}
