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

namespace GidraSIM.DB
{
    /// <summary>
    /// Interaction logic for ResourceNamesWindow.xaml
    /// </summary>
    public partial class ResourceNamesWindow : Window
    {
        SimSaprNewEntities db;
        //List<ResourceNames> ResourceNames;

        public ResourceNamesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceNames.Load();
            resourcesGrid.ItemsSource = db.ResourceNames.ToList();
            //ResourceNames = db.ResourceNames.Local.ToBindingList();
            //resourcesGrid.ItemsSource = ResourceNames;

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resName = new ResourceNames();
            var dialog = new ResourceNameEditWindow(resName);

            if (dialog.ShowDialog() == true)
            {
                db.ResourceNames_Create(resName.Name, 1);

                resourcesGrid.ItemsSource = null;
                resourcesGrid.ItemsSource = db.ResourceNames.ToList();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourcesGrid.SelectedItems.Count > 0)
            {
                var resName = resourcesGrid.SelectedItems[0] as ResourceNames;

                if (resName == null)
                    return;

                var dialog = new ResourceNameEditWindow(resName);

                if (dialog.ShowDialog() == true)
                {
                    db.ResourceTypes_Update(resName.ResourceNameId, resName.Name);

                    resourcesGrid.ItemsSource = null;
                    resourcesGrid.ItemsSource = db.ResourceNames.ToList();
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourcesGrid.SelectedItems.Count > 0)
            {
                var resName = resourcesGrid.SelectedItems[0] as ResourceNames;

                if (resName == null)
                    return;

                db.ResourceNames_Delete(resName.ResourceNameId);
                resourcesGrid.ItemsSource = null;
                resourcesGrid.ItemsSource = db.ResourceNames.ToList();
            }
        }
    }
}
