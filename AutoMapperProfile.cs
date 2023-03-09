using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using new_project.Models;
using new_project.Dtos;
using AutoMapper;

namespace new_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}