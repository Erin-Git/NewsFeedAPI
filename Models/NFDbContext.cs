using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeedAPI.Models
{
    public class NFDbContext : DbContext
    {
        public NFDbContext(DbContextOptions<NFDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
    }
}
