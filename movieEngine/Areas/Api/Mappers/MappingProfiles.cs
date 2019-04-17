using AutoMapper;
using movieEngine.Data.Models;
using movieEngine.Web.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Actor, ActorRequest>()
                .ForMember(dest => dest.Id, source => source.MapFrom(a => a.ActorId))
                .ForMember(dest => dest.Firstname, source => source.MapFrom(a => a.Firstname))
                .ForMember(dest => dest.Lastname, source => source.MapFrom(a => a.Lastname));

            CreateMap<Title, TitleResponse>()
                .ForMember(dest => dest.Id, source => source.MapFrom(t => t.TitleId))
                .ForMember(dest => dest.Name, source => source.MapFrom(t => t.Name))
                .ForMember(dest => dest.Description, source => source.MapFrom(t => t.Description))
                .ForMember(dest => dest.ImagePath, source => source.MapFrom(t => t.Image))
                .ForMember(dest => dest.Rating, source => source.MapFrom(t => t.Rating))
                .ForMember(dest => dest.Released, source => source.MapFrom(t => t.Released.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Type, source => source.MapFrom(t => t.Type.Name));
        }
    }
}
