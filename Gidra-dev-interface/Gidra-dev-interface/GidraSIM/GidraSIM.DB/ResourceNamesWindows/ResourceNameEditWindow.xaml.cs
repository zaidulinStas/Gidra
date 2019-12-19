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

namespace GidraSIM.DB
{
    /// <summary>
    /// Interaction logic for ResourceNameEditWindow.xaml
    /// </summary>
    public partial class ResourceNameEditWindow : Window
    {
        ResourceNames resName;
        public ResourceNameEditWindow(ResourceNames _resName)
        {
            InitializeComponent();
            resName = _resName;
            tb_name.Text = resName.Name;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            resName.Name = tb_name.Text;
            DialogResult = true;
        }
    }
}
