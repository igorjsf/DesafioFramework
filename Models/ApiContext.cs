using Microsoft.EntityFrameworkCore;
using Desafio.Models;

namespace Desafio.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Fotos { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
