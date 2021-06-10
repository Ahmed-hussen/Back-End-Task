using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPost_API.Data;
using BlogPost_API.Models;
using Microsoft.EntityFrameworkCore;


namespace BlogPost_API.Data
{
    public class BlogRepo : IBlogRepo
    {
        private readonly DataContext _context; 

        public BlogRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }


        public async Task  Delete <T>(T entity) where T : class
        {
            _context.Remove(entity);
           await   _context.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Post>> getAllPosts()
        {
          var posts=await _context.Posts.ToListAsync();
          return posts;
        }

        public async Task<Post> getPostId(int id)
        {
          var post=await _context.Posts.Include(i=>i.Comments).FirstOrDefaultAsync(i=>i.Id==id);
          return post;
        }

               public async Task<Comment> getCommentId(int id)
        {
          var Comment=await _context.Comments.Where(i=>i.Id==id).FirstOrDefaultAsync();
          return Comment;
        }
    }
}