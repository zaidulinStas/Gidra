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
        List<ResourceTypes> ResourceTypes;

        public ResourceNamesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceNames.Load();
            db.ResourceTypes.Load();
            //ResourceTypes = db.ResourceTypes.ToList();
            resourcesGrid.ItemsSource = db.ResourceNames.ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resName = new ResourceNames();
            var dialog = new ResourceNameEditWindow(resName, ResourceTypes, true);

            if (dialog.ShowDialog() == true)
            {
                db.ResourceNames_Create(resName.Name, resName.ResourceTypeId);

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

                var dialog = new ResourceNameEditWindow(resName, ResourceTypes, false);

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

        private void btn_resNamePar_Click(object sender, RoutedEventArgs e)
        {
            var resName = new ResourceNames();

            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    resName = row.Item as ResourceNames;

                    break;
                }

            var dialog = new ResourceParameterNamesWindow(resName);
            dialog.ShowDialog();
        }
    }
}
