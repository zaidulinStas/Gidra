using System.Data.Entity;

namespace GidraSIM.NewDataBase
{
    class GidraDbContext : DbContext
    {
        public GidraDbContext() : base("DefaultConnection")
        { }

        public DbSet<Process> processes { get; set; }
        public DbSet<Resource> resources { get; set; }
        public DbSet<Property> properties { get; set; }
    }
}
