using AutoMapper;
using Practice_8.DTOs;
using Practice_8.Models;

namespace Practice_8.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Music, MusicDto>().ReverseMap();
        }
    }
}
