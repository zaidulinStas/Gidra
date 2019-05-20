using System.Collections.Generic;
using System.Data.Entity;

namespace GidraSIM.NewDataBase
{
    public class ProcessRepository : IRepository<Process>
    {
        private GidraDbContext db;

        public ProcessRepository(GidraDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Process> GetList()
        {
            return db.Processes;
        }

        public Process Get(int id)
        {
            return db.Processes.Find(id);
        }

        public void Create(Process process)
        {
            db.Processes.Add(process);
        }

        public void Update(Process process)
        {
            db.Entry(process).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Process process = db.Processes.Find(id);
            if (process != null)
                db.Processes.Remove(process);
        }
    }
}
