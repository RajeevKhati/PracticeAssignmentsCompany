using AutoMapper;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.EventDomain.AppServices.Mapper
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<EventDTO, Event>().ReverseMap();
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<EventAndPersonDTO, EventAndPerson>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ReverseMap();
        }
    }
}
