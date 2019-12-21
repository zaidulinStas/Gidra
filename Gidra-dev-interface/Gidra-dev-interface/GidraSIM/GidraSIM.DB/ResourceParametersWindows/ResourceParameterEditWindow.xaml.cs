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

namespace GidraSIM.DB.ResourceParametersWindows
{
    /// <summary>
    /// Interaction logic for ResourceParameterEditWindow.xaml
    /// </summary>
    public partial class ResourceParameterEditWindow : Window
    {
        ResourceParameters resParam;

        public ResourceParameterEditWindow(ResourceParameters _resParam)
        {
            InitializeComponent();
            resParam = _resParam;
            tb_value.Text = _resParam.Value.ToString();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            resParam.Value = Convert.ToDouble(tb_value.Text);
            DialogResult = true;
        }
    }
}
