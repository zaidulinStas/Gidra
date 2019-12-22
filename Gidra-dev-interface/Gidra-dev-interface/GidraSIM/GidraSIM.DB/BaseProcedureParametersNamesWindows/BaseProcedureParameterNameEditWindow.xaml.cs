using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GidraSIM.DB.BaseProcedureParametersNamesWindows
{
    /// <summary>
    /// Interaction logic for BaseProcedureParameterNameEditWindow.xaml
    /// </summary>
    public partial class BaseProcedureParameterNameEditWindow : Window
    {
        BaseProcedureParameterNames procParamName;

        public BaseProcedureParameterNameEditWindow(BaseProcedureParameterNames _procParamName)
        {
            InitializeComponent();
            procParamName = _procParamName;
            tb_name.Text = procParamName.Name;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            procParamName.Name = tb_name.Text;
            DialogResult = true;
        }
    }
}
