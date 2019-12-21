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

        public ResourcesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceNames.Load();
            db.Resources.Load();
            ResourceNames = db.ResourceNames.ToList();
            resourcesGrid.ItemsSource = db.Resources.ToList();

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
                db.Resources_Create(resource.ResourceNameId, resource.Name, resource.Price);

                resourcesGrid.ItemsSource = null;
                resourcesGrid.ItemsSource = db.Resources.ToList();
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
                    db.Resources_Update(resource.ResourceNameId, resource.Name, resource.Price);

                    resourcesGrid.ItemsSource = null;
                    resourcesGrid.ItemsSource = db.Resources.ToList();
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
                resourcesGrid.ItemsSource = db.Resources.ToList();
            }
        }

        void btn_resPar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
