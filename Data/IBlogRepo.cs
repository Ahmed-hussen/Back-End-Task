using System.Collections.Generic;
using System.Threading.Tasks;
using BlogPost_API.Models;

namespace BlogPost_API.Data
{
    public interface IBlogRepo
    {

        void Add<T>(T entity) where T : class;// Add Any entity
        Task Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        // Post
        Task <IEnumerable<Post>> getAllPosts();
        Task<Post> getPostId(int id);
        Task<Comment> getCommentId(int id);

  
    }
}