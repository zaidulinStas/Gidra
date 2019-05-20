using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.NewDataBase
{
    public class PropertyRepository : IRepository<Property>
    {
        private GidraDbContext db;

        public PropertyRepository(GidraDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Property> GetList()
        {
            return db.Properties;
        }

        public Property Get(int id)
        {
            return db.Properties.Find(id);
        }

        public void Create(Property property)
        {
            db.Properties.Add(property);
        }

        public void Update(Property property)
        {
            db.Entry(property).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Property property = db.Properties.Find(id);
            if (property != null)
                db.Properties.Remove(property);
        }
    }
}
