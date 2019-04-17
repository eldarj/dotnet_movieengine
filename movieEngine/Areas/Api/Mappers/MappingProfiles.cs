using AutoMapper;
using movieEngine.Data;
using movieEngine.Data.Models;
using movieEngine.Web.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Mappers
{
    public class MappingProfiles : Profile
    {
        protected readonly MyDbContext db;

        public MappingProfiles(MyDbContext ctx)
        {
            db = ctx;
        
        // --- profiles ---

            CreateMap<Actor, ActorResponse>()
                .ForMember(dest => dest.Id, source => source.MapFrom(a => a.ActorId))
                .ForMember(dest => dest.Firstname, source => source.MapFrom(a => a.Firstname))
                .ForMember(dest => dest.Lastname, source => source.MapFrom(a => a.Lastname));

            CreateMap<ActorResponse, Actor>()
                .ForMember(dest => dest.ActorId, options => options.Ignore())
                .ForMember(dest => dest.Titles, options => options.Ignore())
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

            CreateMap<TitleResponse, Title>()
                .ForMember(dest => dest.TitleId, options => options.Ignore())
                .ForMember(dest => dest.Actors, options => options.Ignore())
                .ForMember(dest => dest.TitleTypeId, options => options.Ignore())
                .ForMember(dest => dest.Name, source => source.MapFrom(t => t.Name))
                .ForMember(dest => dest.Description, source => source.MapFrom(t => t.Description))
                .ForMember(dest => dest.Image, source => source.MapFrom(t => t.ImagePath))
                .ForMember(dest => dest.Rating, source => source.MapFrom(t => t.Rating))
                .ForMember(dest => dest.Released, source => source.MapFrom(t => DateTime.ParseExact(t.Released, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Type, source => source.MapFrom(t => db.TitleTypes.Where(tt => tt.Name == t.Type).SingleOrDefault()));
        }
    }
}
