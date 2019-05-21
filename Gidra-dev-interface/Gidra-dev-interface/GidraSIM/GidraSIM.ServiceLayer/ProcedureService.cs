using GidraSIM.DataLayer;
using GidraSIM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.ServiceLayer
{
    public class ProcedureService
    {
        private readonly ApplicationDbContext _db;

        public ProcedureService(string connectionString)
        {
            _db = new ApplicationDbContext(connectionString);
        }

        public void Create(Core.Model.Procedure entity)
        {
            _db.Procedures.Add(Map(entity));
            _db.SaveChanges();
        }

        public List<Core.Model.Procedure> GetAll()
        {
            return _db.Procedures.Select(InverseMap).ToList();
        }

        public void Remove(Core.Model.Procedure entity)
        {
            _db.Procedures.Remove(_db.Procedures.First(x => x.Name == entity.Name));
        }

        public void Update(Core.Model.Procedure entity)
        {
            throw new NotImplementedException();
        }

        private Core.Model.Procedure InverseMap(Procedure procedure)
        {
            return new Core.Model.Procedure
            {
                Name = procedure.Name,
                ProgressFunction = procedure.ProgressFunction,
                Parameters = procedure.Parameters.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        private Procedure Map(Core.Model.Procedure procedure)
        {
            return new Procedure
            {
                Name = procedure.Name,
                ProgressFunction = procedure.ProgressFunction,
                Parameters = procedure.Parameters.Select(x => new Parameter
                {
                    Key = x.Key,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}
