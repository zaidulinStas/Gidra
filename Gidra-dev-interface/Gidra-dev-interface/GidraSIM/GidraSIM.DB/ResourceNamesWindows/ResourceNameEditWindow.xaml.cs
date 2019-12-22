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
        List<ResourceTypes> ResourceTypes;
        ResourceTypes SelectedResourceType;
        bool IsNew;

        public ResourceNameEditWindow(ResourceNames _resName, List<ResourceTypes> resourceTypes, bool isNew)
        {
            InitializeComponent();
            ResourceTypes = resourceTypes;
            IsNew = isNew;
            resName = _resName;
            tb_name.Text = resName.Name;

            if (IsNew)
            {
                lv_types.ItemsSource = ResourceTypes;
                lv_types.SelectedIndex = 0;
                SelectedResourceType = lv_types.SelectedItem as ResourceTypes;
                lv_types.Visibility = Visibility.Visible;
            }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsNew)
            {
                SelectedResourceType = lv_types.SelectedItem as ResourceTypes;
                if (SelectedResourceType == null)
                {
                    MessageBox.Show("Выберите тип ресурса");
                    return;
                }
                resName.ResourceTypeId = SelectedResourceType.ResourceTypeId;
            }

            resName.Name = tb_name.Text;
            DialogResult = true;
        }
    }
}
