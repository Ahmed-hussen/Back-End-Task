using System.Collections.Generic;
namespace BlogPost_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        

        public virtual ICollection<Comment> Comments { get; set; }
        
        
               
    }
}