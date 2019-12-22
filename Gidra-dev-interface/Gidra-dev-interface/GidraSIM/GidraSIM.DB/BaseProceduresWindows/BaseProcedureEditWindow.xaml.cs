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

namespace GidraSIM.DB.BaseProceduresWindows
{
    /// <summary>
    /// Interaction logic for BaseProcedureEditWindow.xaml
    /// </summary>
    public partial class BaseProcedureEditWindow : Window
    {
        BaseProcedures procedure;
        public BaseProcedureEditWindow(BaseProcedures _procedure)
        {
            InitializeComponent();
            procedure = _procedure;
            tb_name.Text = procedure.Name;
            tb_func.Text = procedure.DefaultFunctionExpression;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            procedure.Name = tb_name.Text;
            procedure.DefaultFunctionExpression = tb_func.Text;
            DialogResult = true;
        }
    }
}
