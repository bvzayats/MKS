using AutoMapper;
using NedoNet.API.Data.Models;
using NedoNet.API.Entities;

namespace NedoNet.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Entities -> Models

            CreateMap<User, UserViewEntity>()
                .ForMember(
                    dest => dest.FullName,
                    opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            #endregion

            #region Models -> Entities

            CreateMap<CreateUserEntity, User>();
            CreateMap<UpdateUserEntity, User>();

            #endregion
        }
    }
}