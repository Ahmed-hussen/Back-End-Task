using AutoMapper;
using BlogPost_API.Dtos.Post;
using BlogPost_API.Models;

namespace Souqly_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
         public AutoMapperProfiles()
        {

            CreateMap<PostForAddDto,Post>();// Create
            CreateMap<Post,PostForDetails>();// Get Data
           
            CreateMap<Post,PostForListDto>();// Get Data

            
            CreateMap<CommentForAddDto,Comment>();// Create
            CreateMap<Comment,CommentForDetails>();// Get Data
           
            CreateMap<Comment,CommentForListDto>();// Get Data

        }
    }
}