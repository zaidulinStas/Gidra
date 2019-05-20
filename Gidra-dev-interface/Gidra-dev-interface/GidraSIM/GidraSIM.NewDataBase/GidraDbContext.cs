using System.Data.Entity;

namespace GidraSIM.NewDataBase
{
    public class GidraDbContext : DbContext
    {
        public GidraDbContext() : base("DefaultConnection")
        { }

        public DbSet<Process> Processes { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
