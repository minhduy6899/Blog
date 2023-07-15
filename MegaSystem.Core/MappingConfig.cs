using AutoMapper;
using MegaSystem.Core.Domain.Entities;
using MegaSystem.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //Blog
            CreateMap<Blog, BlogAddRequest>().ReverseMap();
            CreateMap<Blog, BlogUpdateRequest>().ReverseMap();
            CreateMap<Blog, BlogResponse>()
                .ForMember(dest => dest.Posts, opt => opt
                .MapFrom(src => src.Posts.Select(p => p.PostName)));
                
                

            //Post
            CreateMap<Post, PostAddRequest>().ReverseMap();
            CreateMap<Post, PostUpdateRequest>().ReverseMap();
            CreateMap<Post, PostResponse>();

        }
    }
}
