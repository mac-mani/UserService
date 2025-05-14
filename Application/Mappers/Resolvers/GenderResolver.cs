using System;
using Application.DTO;
using Application.Enums;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers.Resolvers;

public class GenderResolver : IValueResolver<RegisterRequest, ApplicationUser, string?>
{
    public string? Resolve(RegisterRequest source, ApplicationUser destination, string? destMember, ResolutionContext context)
    {
        return Enum.TryParse<GenderOptions>(source.Gender, true, out var gender)
            ? gender.ToString()
            : throw new ArgumentException($"Invalid gender: {source.Gender}");
    }
}
