using AutoMapper;
using Company.Project.ProductDomain.AppServices.DTOs;
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
            CreateMap<EventViewModel, ProductDTO>().ReverseMap();
            CreateMap<CommentViewModel, CommentDTO>().ReverseMap();
            //CreateMap<NotificationsViewModel, NotificationDTO>().ReverseMap();
            //CreateMap<UpcomingPassedEventsViewModel, ProductDTO>().ReverseMap();
        }
    }
}
