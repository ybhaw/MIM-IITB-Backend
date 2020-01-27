using System.Collections.Generic;
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
            
            //User mapper
            CreateMap<RegisterUser, User>()
                .ForMember(dest => dest.PasswordSalt,
                    opt => opt.MapFrom(c => Authentication.GenerateSalt()))
                .AfterMap((src, dest) =>
                    dest.PasswordHash = Authentication.GeneratePassword(src.Password, dest.PasswordSalt));
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
            CreateMap<User, UserViewModel>();
            
            
            //AuthUser mapper
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
            


            // Food mappers
            CreateMap<FoodBaseRequest, Food>();
            CreateMap<FoodWithDefaultFoodTypeRequest, Food>()
                .ForMember(dest => dest.FoodTypes,
                    opt => 
                        opt.MapFrom(src => new List<FoodTypeBaseRequest>(){ src.FoodType }))
                .AfterMap((src, dest) => { dest.FoodTypes[0].Food = dest; });
            CreateMap<FoodWithMultipleFoodTypeRequest, Food>()
                .ForMember(dest => dest.FoodTypes,
                    opt =>
                        opt.MapFrom(src => src.FoodTypes))
                .AfterMap((src, dest) => { dest.FoodTypes.ForEach(c => c.Food = dest); });
            
            // FoodType mappers
            CreateMap<FoodTypeBaseRequest, FoodType>();
            CreateMap<FoodTypeWithFoodRequest, FoodType>()
                .ForMember(dest => dest.Food,
                    opt => opt.MapFrom(src => src.Food))
                .AfterMap((src, dest) => dest.Food.FoodTypes = new List<FoodType>() {dest});
            CreateMap<FoodTypeWithFoodIdRequest, FoodType>();
            CreateMap<FoodTypeUpdateRequest, FoodType>();
            CreateMap<Food, FoodBaseViewModel>();
            CreateMap<Food, FoodWithFoodTypesViewModel>();
            CreateMap<FoodType, FoodTypeBaseViewModel>();
            CreateMap<FoodType, FoodTypeWithFoodViewModel>()
                .ForMember(dest=>dest.Food,  
                    opt=>opt.MapFrom(src=>src.Food));
            CreateMap<FoodType, FoodTypeWithFoodIdViewModel>();

            CreateMap<IntakeRequest, Intake>();
            CreateMap<IntakeUpdateRequest, Intake>();
            CreateMap<Intake, IntakeBaseViewModel>();
            CreateMap<Intake, IntakeWithAllIncludes>()
                .ForMember(dest => dest.Food,
                    opt => opt.MapFrom(src => src.Food))
                .ForMember(dest => dest.FoodType,
                    opt => opt.MapFrom(src => src.FoodType));

            CreateMap<IntakeBatchBaseRequest, IntakeBatch>();
            CreateMap<IntakeBatchRequest, IntakeBatch>()
                .ForMember(dest => dest.Intakes,
                    opt => opt.MapFrom(src => src.IntakeRequests));
            CreateMap<IntakeBatchUpdateRequest, IntakeBatch>();
            CreateMap<IntakeBatch, IntakeBatchBaseViewModel>();
            CreateMap<IntakeBatch, IntakeBatchWithAllIncludeViewModel>()
                .ForMember(dest=>dest.Intakes,
                    opt=>opt.MapFrom(src=>src.Intakes))
                .ForMember(dest=>dest.Vendor,
                    opt=>opt.MapFrom(src=>src.Vendor));
        }
    }
}