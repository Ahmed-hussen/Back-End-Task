using System.Collections.Generic;
using BlogPost_API.Models;

namespace BlogPost_API.Dtos.Post
{
    public class PostForDetails
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public  ICollection<Comment> Comments { get; set; }

    }
}