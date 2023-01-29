using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Services.DTO;

namespace AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
        }
    }
}