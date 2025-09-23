using AutoMapper;
using BankingSystem.Application.DTOs;
using BankingSystem.Domain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
