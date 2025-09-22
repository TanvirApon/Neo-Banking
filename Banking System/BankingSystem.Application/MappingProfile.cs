using AutoMapper;
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
           CreateMap<User, DTOs.UserDto>().ReverseMap();
        }
    }
}
