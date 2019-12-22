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

namespace GidraSIM.DB.ResourcesWindows
{
    /// <summary>
    /// Interaction logic for ResourceEditWindow.xaml
    /// </summary>
    public partial class ResourceEditWindow : Window
    {
        Resources resource;
        List<ResourceNames> ResourceNames;
        ResourceNames SelectedResourceName;
        bool IsNew;

        public ResourceEditWindow(Resources _resource, List<ResourceNames> resourceNames, bool isNew)
        {
            InitializeComponent();
            ResourceNames = resourceNames;
            IsNew = isNew;
            resource = _resource;
            tb_name.Text = resource.Name;
            tb_price.Text = resource.Price.ToString();

            if (IsNew)
            {
                lv_names.ItemsSource = ResourceNames;
                lv_names.SelectedIndex = 0;
                SelectedResourceName = lv_names.SelectedItem as ResourceNames;
                lv_names.Visibility = Visibility.Visible;
            }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsNew)
            {
                SelectedResourceName = lv_names.SelectedItem as ResourceNames;
                if (SelectedResourceName == null)
                {
                    MessageBox.Show("Выберите имя ресурса");
                    return;
                }
                resource.ResourceNameId = SelectedResourceName.ResourceNameId;
            }

            resource.Name = tb_name.Text;
            resource.Price = Convert.ToDecimal(tb_price.Text);
            DialogResult = true;
        }
    }
}
