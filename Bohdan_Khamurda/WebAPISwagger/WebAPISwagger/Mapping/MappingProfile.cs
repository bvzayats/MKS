using AutoMapper;
using WebAPISwagger.Models;

namespace WebAPISwagger.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {

            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}