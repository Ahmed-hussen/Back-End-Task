namespace BlogPost_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        
     

        
        
    }
}