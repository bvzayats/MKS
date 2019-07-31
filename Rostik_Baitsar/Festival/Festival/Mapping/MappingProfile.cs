using AutoMapper;
using Festival.Models;

namespace Festival.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Band, BandDTO>();
            CreateMap<BandDTO, Band>();
        }
    }
}
