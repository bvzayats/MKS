using AutoMapper;
using Festival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
