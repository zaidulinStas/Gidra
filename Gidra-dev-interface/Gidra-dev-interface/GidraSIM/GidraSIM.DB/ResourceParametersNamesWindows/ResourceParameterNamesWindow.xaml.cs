using GidraSIM.DB.ResourceParametersNamesWindows;
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
    /// Interaction logic for ResourceParameterNamesWindow.xaml
    /// </summary>
    public partial class ResourceParameterNamesWindow : Window
    {
        SimSaprNewEntities db;
        ResourceNames ResourceNames;

        public ResourceParameterNamesWindow(ResourceNames resourceNames)
        {
            InitializeComponent();
            ResourceNames = resourceNames;

            db = new SimSaprNewEntities();
            db.ResourceParameterNames.Load();
            parametersGrid.ItemsSource = db.ResourceParameterNames.Where(rp => rp.ResourceNameId == ResourceNames.ResourceNameId).Include(rp => rp.ResourceNames).ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resParamName = new ResourceParameterNames();
            var dialog = new ResourceParameterNameEditWindow(resParamName);

            if (dialog.ShowDialog() == true)
            {
                db.ResourceParameterNames_Create(resParamName.Name, ResourceNames.ResourceNameId);

                parametersGrid.ItemsSource = null;
                parametersGrid.ItemsSource = db.ResourceParameterNames.Where(rp => rp.ResourceNameId == ResourceNames.ResourceNameId).Include(rp => rp.ResourceNames).ToList();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (parametersGrid.SelectedItems.Count > 0)
            {
                var resParamName = parametersGrid.SelectedItems[0] as ResourceParameterNames;

                if (resParamName == null)
                    return;

                var dialog = new ResourceParameterNameEditWindow(resParamName);

                if (dialog.ShowDialog() == true)
                {
                    db.ResourceParameterNames_Update(resParamName.ResourceParameterNameId, resParamName.Name);

                    parametersGrid.ItemsSource = null;
                    parametersGrid.ItemsSource = db.ResourceParameterNames.Where(rp => rp.ResourceNameId == ResourceNames.ResourceNameId).Include(rp => rp.ResourceNames).ToList();
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (parametersGrid.SelectedItems.Count > 0)
            {
                var resParamName = parametersGrid.SelectedItems[0] as ResourceParameterNames;

                if (resParamName == null)
                    return;

                db.ResourceParameterNames_Delete(resParamName.ResourceParameterNameId);
                parametersGrid.ItemsSource = null;
                parametersGrid.ItemsSource = db.ResourceParameterNames.Where(rp => rp.ResourceNameId == ResourceNames.ResourceNameId).Include(rp => rp.ResourceNames).ToList();
            }
        }
    }
}
