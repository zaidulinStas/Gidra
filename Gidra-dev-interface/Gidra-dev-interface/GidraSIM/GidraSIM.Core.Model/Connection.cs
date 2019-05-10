using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Класс соединения
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Очередь токенов
        /// </summary>
        public Queue<Token> Tokens { get; set; }

        /// <summary>
        /// Начало соединения
        /// </summary>
        public Procedure Begin { get; set; }

        /// <summary>
        /// Конец соединения
        /// </summary>
        public Procedure End { get; set; }
    }
}
