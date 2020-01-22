using AutoMapper;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Models.User;
using MIM_IITB.Data.Models;

namespace MIM_IITB.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}