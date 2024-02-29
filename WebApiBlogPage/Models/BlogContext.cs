using Microsoft.EntityFrameworkCore;

namespace WebApiBlogPage.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { 
        
        }
            public virtual DbSet<AdminInfo> AdminInfos { get; set; }

             public virtual DbSet<BlogInfo> BlogInfos { get; set; }

             public virtual DbSet<EmpInfo> EmpInfos { get; set; }
    }
 }

