using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.ServiceLayer
{
    public interface CRUDService<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> GetAll ();
    }
}
