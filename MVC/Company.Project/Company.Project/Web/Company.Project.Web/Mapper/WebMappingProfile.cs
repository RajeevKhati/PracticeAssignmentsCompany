using AutoMapper;
using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Mapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() : base("WebMappingProfile")
        {
            //CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<EventViewModel, EventDTO>().ReverseMap();
            CreateMap<PersonViewModel, PersonDTO>().ReverseMap();
            CreateMap<CommentViewModel, CommentDTO>().ReverseMap();
            CreateMap<CommentNotificationViewModel, CommentNotificationDTO>().ReverseMap();
        }
    }
}
