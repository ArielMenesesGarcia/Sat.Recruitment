using System;
using AutoMapper;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Domain.Entity;

namespace Sat.Recruitment.Transversal.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO,User>().ReverseMap();
        }
    }
}
