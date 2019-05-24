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
    public class ResourceService
    {
        private readonly ApplicationDbContext _db;

        public ResourceService(string connectionString)
        {
            _db = new ApplicationDbContext(connectionString);
        }

        public void Create(Core.Model.Resource entity)
        {
            _db.Resources.Add(_Map(entity));
            _db.SaveChanges();
        }

        public List<Core.Model.Resource> GetAll()
        {
            return _db.Resources
                .Include("Parameters")
                .Select(_InverseMap)
                .ToList();
        }

        public void Remove(Core.Model.Resource entity)
        {
            var resource = _db.Resources.First(x => x.Name == entity.Name);
            _db.Resources.Remove(resource);
        }

        public void Update(Core.Model.Resource entity)
        {
            var resource = _db.Resources.First(x => x.Name == entity.Name);
            var mappedEntity = _Map(entity);

            resource.Parameters = mappedEntity.Parameters;

            _db.SaveChanges();
        }

        private Core.Model.Resource _InverseMap(Resource procedure)
        {
            return new Core.Model.Resource
            {
                Name = procedure.Name,
                Parameters = procedure.Parameters.ToDictionary(x => x.Key, x => x.Value)
            };
        }

        private Resource _Map(Core.Model.Resource procedure)
        {
            return new Resource
            {
                Name = procedure.Name,
                Parameters = procedure.Parameters.Select(x => new Parameter
                {
                    Key = x.Key,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}

