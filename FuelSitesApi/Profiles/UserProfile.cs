using AutoMapper;
using FuelSitesApi.DTOs.UserDTOs;

namespace FuelSitesApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserLoginDTO>().ReverseMap();
        }
    }
}
