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

namespace GidraSIM.DB.ResourceTypesWindows
{
    /// <summary>
    /// Interaction logic for ResourceTypeEditWindow.xaml
    /// </summary>
    public partial class ResourceTypeEditWindow : Window
    {
        ResourceTypes resЕype;
        public ResourceTypeEditWindow(ResourceTypes _restype)
        {
            InitializeComponent();
            resЕype = _restype;
            tb_name.Text = resЕype.Name;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            resЕype.Name = tb_name.Text;
            DialogResult = true;
        }
    }
}
