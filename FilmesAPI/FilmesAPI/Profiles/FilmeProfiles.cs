using AutoMapper;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfiles : Profile
    {
        public FilmeProfiles()
        {
            CreateMap<CreateFilmesDTo, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
