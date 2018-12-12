using AudioAgentTest.Model;
using Microsoft.EntityFrameworkCore;

namespace AudioAgentTest.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ImagesStorage> ImagesStorage { get; set; }
    }
}
