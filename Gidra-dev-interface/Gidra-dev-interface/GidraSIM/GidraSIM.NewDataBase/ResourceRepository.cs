using System.Collections.Generic;
using System.Data.Entity;

namespace GidraSIM.NewDataBase
{
    public class ResourceRepository : IRepository<Resource>
    {
        private GidraDbContext db;

        public ResourceRepository(GidraDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Resource> GetList()
        {
            return db.Resources;
        }

        public Resource Get(int id)
        {
            return db.Resources.Find(id);
        }

        public void Create(Resource resource)
        {
            db.Resources.Add(resource);
        }

        public void Update(Resource resource)
        {
            db.Entry(resource).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Resource resource = db.Resources.Find(id);
            if (resource != null)
                db.Resources.Remove(resource);
        }
    }
}
