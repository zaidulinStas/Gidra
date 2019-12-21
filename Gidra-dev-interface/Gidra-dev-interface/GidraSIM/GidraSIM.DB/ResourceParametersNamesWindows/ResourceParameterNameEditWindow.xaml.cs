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

namespace GidraSIM.DB.ResourceParametersNamesWindows
{
    /// <summary>
    /// Interaction logic for ResourceParameterNameEditWindow.xaml
    /// </summary>
    public partial class ResourceParameterNameEditWindow : Window
    {
        ResourceParameterNames resParamName;

        public ResourceParameterNameEditWindow(ResourceParameterNames _resParamName)
        {
            InitializeComponent();
            resParamName = _resParamName;
            tb_name.Text = _resParamName.Name;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            resParamName.Name = tb_name.Text;
            DialogResult = true;
        }
    }
}
