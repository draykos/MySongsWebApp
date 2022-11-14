using AutoMapper;
using MySongs.DAL.Students;
using MySongs.DAL.Models;
using MySongs.DTO;

namespace MySongs.BLL;

public class MappingProfile : Profile
{

    public MappingProfile() 
    {
        CreateMap<Student, StudentDTO>().ReverseMap()
            .ForMember(dest => dest.Enrollments, opt => opt.AllowNull());
        CreateMap<Student, StudentCreateDTO>().ReverseMap();
        CreateMap<Song, SongDTO>().ReverseMap();


    }
}
