using GidraSIM.Core.Model;
using System.Windows.Controls;

namespace GidraSIM.GUI.Utility
{
    public interface IViewModelConverter
    {
        /// <summary>
        /// преобразование из графики в процесс
        /// </summary>
        /// <param name="uIElementCollection">набор WPF-блоков</param>
        /// <param name="simulator">пустой симулятор для отображения</param>
        void Map(UIElementCollection uIElementCollection, SimulationOptions simOptions);
    }
}
