using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.NewDataBase
{
    public class UnitOfWork : IDisposable
    {
        private GidraDbContext db = new GidraDbContext();
        private ProcessRepository processRepository;
        private ResourceRepository resourceRepository;
        private PropertyRepository propertyRepository;

        public ProcessRepository Processes
        {
            get
            {
                if (processRepository == null)
                    processRepository = new ProcessRepository(db);
                return processRepository;
            }
        }

        public ResourceRepository Resources
        {
            get
            {
                if (resourceRepository == null)
                    resourceRepository = new ResourceRepository(db);
                return resourceRepository;
            }
        }

        public PropertyRepository Properties
        {
            get
            {
                if (propertyRepository == null)
                    propertyRepository = new PropertyRepository(db);
                return propertyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
