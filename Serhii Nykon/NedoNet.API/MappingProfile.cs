using AutoMapper;
using NedoNet.API.BindingModels;
using NedoNet.API.Data.Entities;
using NedoNet.API.Models;

namespace NedoNet.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Entities -> Models

            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.FullName,
                    opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            #endregion

            #region BindingModels -> Models

            CreateMap<UserBindingModel, UserViewModel>()
                .ForMember(
                    dest => dest.FullName,
                    opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            #endregion
        }
    }
}