using BlogPost_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPost_API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        
     protected override void OnModelCreating(ModelBuilder builder)
        {
              base.OnModelCreating(builder);
              builder.Entity<Comment>()
                .HasOne<Post>(s => s.Post)
                .WithMany(ta => ta.Comments)
                .HasForeignKey(u => u.PostId)
                .OnDelete(DeleteBehavior.Restrict);

              //  base.OnModelCreating(builder);
              // builder.Entity<Order>()
              //   .HasOne<User>(s => s.Marketing)
              //   .WithMany(ta => ta.Orders)
              //   .HasForeignKey(u => u.MarketingId)
              //   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}