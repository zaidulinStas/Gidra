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
        List<ResourceNames> resourceNames;
        ResourceParameterNames resParamName;
        ResourceNames SelectedResourceName;

        public ResourceParameterNameEditWindow(ResourceParameterNames _resParamName, List<ResourceNames> _resourceNames)
        {
            InitializeComponent();
            resParamName = _resParamName;
            resourceNames = _resourceNames;
            tb_name.Text = _resParamName.Name;
            lv_resources.ItemsSource = resourceNames;
            lv_resources.SelectedIndex = 0;
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            var selResName = lv_resources.SelectedItem as ResourceNames;

            if (selResName == null)
                return;

            resParamName.Name = tb_name.Text;
            resParamName.ResourceNameId = selResName.ResourceNameId;
            DialogResult = true;
        }
    }
}
