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
        List<ResourceNames> ResourceNames;

        public ResourceParameterNamesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ResourceParameterNames.Load();
            ResourceNames = db.ResourceNames.ToList();
            parametersGrid.ItemsSource = db.ResourceParameterNames.Include(rp => rp.ResourceNames).ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var resParamName = new ResourceParameterNames();
            var dialog = new ResourceParameterNameEditWindow(resParamName, ResourceNames);

            if (dialog.ShowDialog() == true)
            {
                db.ResourceParameterNames_Create(resParamName.Name, resParamName.ResourceNameId);

                parametersGrid.ItemsSource = null;
                parametersGrid.ItemsSource = db.ResourceNames.ToList();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
