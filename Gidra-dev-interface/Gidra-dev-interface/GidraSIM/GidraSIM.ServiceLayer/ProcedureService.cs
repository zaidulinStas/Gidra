using GidraSIM.DataLayer;
using GidraSIM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _db.Procedures.Add(_Map(entity));
            _db.SaveChanges();
        }

        public List<Core.Model.Procedure> GetAll()
        {
            return _db.Procedures
                .Include("Parameters")
                .Select(_InverseMap)
                .ToList();
        }

        public void Remove(Core.Model.Procedure entity)
        {
            var procedure = _db.Procedures.First(x => x.Name == entity.Name);
            _db.Procedures.Remove(procedure);
        }

        public void Update(Core.Model.Procedure entity)
        {
            var procedure = _db.Procedures.First(x => x.Name == entity.Name);
            var mappedEntity = _Map(entity);

            procedure.Parameters = mappedEntity.Parameters;
            procedure.ProgressFunction = mappedEntity.ProgressFunction;

            _db.SaveChanges();
        }

        private Core.Model.Procedure _InverseMap(Procedure procedure)
        {
            return new Core.Model.Procedure
            {
                Name = procedure.Name,
                ProgressFunction = procedure.ProgressFunction,
                Parameters = procedure.Parameters.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        private Procedure _Map(Core.Model.Procedure procedure)
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
