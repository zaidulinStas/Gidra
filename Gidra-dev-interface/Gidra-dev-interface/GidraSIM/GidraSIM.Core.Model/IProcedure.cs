using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Интерфейс процедуры
    /// </summary>
    public interface IProcedure
    {
        string Name { get; }

        IList<Connection> Inputs { get; }

        IList<Connection> Outputs { get; }

        void Update(double curTime);
    }
}
