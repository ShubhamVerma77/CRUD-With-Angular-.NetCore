using DummySample.Server.Model;
using DummySample.Server.TestModel;
using Microsoft.EntityFrameworkCore;

namespace DummySample.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)
        {
            
        }
        public DbSet<Demo> DummyTable { get; set; }
        public DbSet<GetAllDataModel> GetAllDataModel { get; set; }
    }
}
