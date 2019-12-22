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

namespace GidraSIM.DB.ResourceTypesWindows
{
    /// <summary>
    /// Interaction logic for ResourceTypesWindow.xaml
    /// </summary>
    public partial class ResourceTypesWindow : Window
    {
        SimSaprNewEntities db;

        public ResourceTypesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceTypes.Load();
            resTypesGrid.ItemsSource = db.ResourceTypes.ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resType = new ResourceTypes();
            var dialog = new ResourceTypeEditWindow(resType);

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    db.ResourceTypes_Create(resType.Name);

                    resTypesGrid.ItemsSource = null;
                    resTypesGrid.ItemsSource = db.ResourceTypes.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введённые значения");
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (resTypesGrid.SelectedItems.Count > 0)
            {
                var resType = resTypesGrid.SelectedItems[0] as ResourceTypes;

                if (resType == null)
                    return;

                var dialog = new ResourceTypeEditWindow(resType);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        db.ResourceTypes_Update(resType.ResourceTypeId, resType.Name);

                        resTypesGrid.ItemsSource = null;
                        resTypesGrid.ItemsSource = db.ResourceTypes.ToList();
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
            if (resTypesGrid.SelectedItems.Count > 0)
            {
                var resType = resTypesGrid.SelectedItems[0] as ResourceTypes;

                if (resType == null)
                    return;

                db.ResourceTypes_Delete(resType.ResourceTypeId);
                resTypesGrid.ItemsSource = null;
                resTypesGrid.ItemsSource = db.ResourceTypes.ToList();
            }
        }
    }
}
