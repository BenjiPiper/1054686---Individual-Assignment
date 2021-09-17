using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Models
{
    public class NewsDataContext : DbContext  
    {
        public DbSet<Post> Posts { get; set; }
            public NewsDataContext(DbContextOptions<NewsDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
