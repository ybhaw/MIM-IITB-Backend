using AutoMapper;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;

namespace MIM_IITB.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            //creating new user with hashed passwords
            CreateMap<RegisterUser, User>()
                .ForMember(dest => dest.PasswordSalt,
                    opt => opt.MapFrom(c => Authentication.GenerateSalt()))
                .AfterMap((src, dest) =>
                    dest.PasswordHash = Authentication.GeneratePassword(src.Password, dest.PasswordSalt));
            CreateMap<User, UserViewModel>();
            
            CreateMap<AuthUser, TokenedUserViewModel>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest=>dest.Email,
                    opt=>opt.MapFrom(src=>src.User.Email))
                .ForMember(dest=>dest.Id,
                    opt=>opt.MapFrom(src=>src.User.Id))
                .ForMember(dest=>dest.Token,
                    opt=>opt.MapFrom(src=>src.Token))
                .ForMember(dest=>dest.ExpiresIn,
                    opt=>opt.MapFrom(src=>src.ExpiresIn))
                .ForMember(dest=>dest.Remembered,
                    opt=>opt.MapFrom(src=>src.Remember));
            
            CreateMap<UpdateUser, User>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.UpdatedName ?? src.Name))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.UpdatedEmail ?? src.Email))
                .AfterMap((src, dest) =>
                {
                    var salt = Authentication.GenerateSalt();
                    dest.PasswordSalt = src.UpdatedPassword != null
                        ? salt
                        : dest.PasswordSalt;
                    dest.PasswordHash = src.UpdatedPassword != null
                        ? Authentication.GeneratePassword(src.UpdatedPassword, salt)
                        : dest.PasswordHash;
                });
        }
    }
}