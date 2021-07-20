using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Web2.Models;

namespace Blog.Web2.Data
{
    public class BlogWeb2Context : DbContext
    {
        public BlogWeb2Context (DbContextOptions<BlogWeb2Context> options)
            : base(options)
        {
        }

        public DbSet<Blog.Web2.Models.Post> Post { get; set; }
    }
}
