using AutoMapper;
using ShopCenter.MVC.Models;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, CreateUserVM>().ReverseMap();
            CreateMap<UserDTO, UserVM>().ReverseMap();
        }
    }
}
