using GidraSIM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        private DbSet<Procedure> Procedures { get; set; }
        private DbSet<Resource> Resources { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public ApplicationDbContext(string nameOrconnectionString) : base(nameOrconnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

