using JobSearch.API.Models;
using JobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.API.Database
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
