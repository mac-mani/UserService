using Application.DTO;
using Application.Enums;
using Application.Mappers.Resolvers;
using AutoMapper;
using Domain.Entities;


namespace Application.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthResponse>()
            .ConstructUsing(src => new AuthResponse(
                src.UserId,
                src.Email,
                src.PersonName,
                src.Gender,
                null,
                false
            ));
            
        CreateMap<RegisterRequest, ApplicationUser>()
        .ForMember(
            d=>d.Gender, 
            o=>o.MapFrom<GenderResolver>());
    }
}

/*.ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
            .ForMember(d => d.PersonName, o => o.MapFrom(s => s.PersonName))
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender))
            .ForMember(d => d.Success, o => o.Ignore())
            .ForMember(d=>d.Token, o=>o.Ignore());*/
