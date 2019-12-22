using GidraSIM.DB.ResourceParametersWindows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for ResourcesWindow.xaml
    /// </summary>
    public partial class ResourcesWindow : Window
    {
        SimSaprNewEntities db;
        List<ResourceNames> ResourceNames;
        List<ResourceParameterNames> ResourceParameterNames;

        public ResourcesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceNames.Load();
            db.Resources.Load();
            ResourceNames = db.ResourceNames.ToList();
            ResourceParameterNames = db.ResourceParameterNames.ToList();
            resourcesGrid.ItemsSource = db.Resources.Include(r => r.ResourceNames).ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resource = new Resources();
            var dialog = new ResourceEditWindow(resource, ResourceNames, true);

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    db.Resources_Create(resource.ResourceNameId, resource.Name, resource.Price);

                    resourcesGrid.ItemsSource = null;
                    resourcesGrid.ItemsSource = db.Resources.Include(r => r.ResourceNames).ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введённые значения");
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourcesGrid.SelectedItems.Count > 0)
            {
                var resource = resourcesGrid.SelectedItems[0] as Resources;

                if (resource == null)
                    return;

                var dialog = new ResourceEditWindow(resource, ResourceNames, false);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        db.Resources_Update(resource.ResourceNameId, resource.Name, resource.Price);

                        resourcesGrid.ItemsSource = null;
                        resourcesGrid.ItemsSource = db.Resources.Include(r => r.ResourceNames).ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Проверьте введённые значения");
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourcesGrid.SelectedItems.Count > 0)
            {
                var resource = resourcesGrid.SelectedItems[0] as Resources;

                if (resource == null)
                    return;

                db.Resources_Delete(resource.ResourceNameId);
                resourcesGrid.ItemsSource = null;
                resourcesGrid.ItemsSource = db.Resources.Include(r => r.ResourceNames).ToList();
            }
        }

        void btn_resPar_Click(object sender, RoutedEventArgs e)
        {
            var resource = new Resources();

            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    resource = row.Item as Resources;

                    break;
                }

            var dialog = new ResourceParametersWindow(resource);
            dialog.ShowDialog();
        }
    }
}
