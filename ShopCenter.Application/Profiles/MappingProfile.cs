using AutoMapper;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region User

            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();

            #endregion
        }
    }
}
