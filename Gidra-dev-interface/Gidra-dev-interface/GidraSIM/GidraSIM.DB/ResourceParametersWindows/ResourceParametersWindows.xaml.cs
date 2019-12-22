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

namespace GidraSIM.DB.ResourceParametersWindows
{
    /// <summary>
    /// Interaction logic for ResourceParametersWindows.xaml
    /// </summary>
    public partial class ResourceParametersWindow : Window
    {
        SimSaprNewEntities db;
        Resources Resource;

        public ResourceParametersWindow(Resources resource)
        {
            InitializeComponent();
            Resource = resource;

            db = new SimSaprNewEntities();
            db.ResourceParameters.Load();
            var resourceParameters = db.ResourceParameters.Include(rp => rp.Resources).Include(rp => rp.ResourceParameterNames).Where(rp => rp.ResourceId == Resource.ResourceId).ToList();
            var resourceParameterNames = db.ResourceParameterNames.Include(rp => rp.ResourceNames).Where(rp => rp.ResourceNameId == Resource.ResourceNameId).ToList();

            if (resourceParameters.Count == 0)
            {
                foreach (var parName in resourceParameterNames)
                {
                    db.ResourceParameters_Create(parName.ResourceParameterNameId, Resource.ResourceId, null);
                }
                resourceParameters = db.ResourceParameters.Where(rp => rp.ResourceId == Resource.ResourceId).Include(rp => rp.Resources).Include(rp => rp.ResourceParameterNames).ToList();
            }

            parametersGrid.ItemsSource = resourceParameters;

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (parametersGrid.SelectedItems.Count > 0)
            {
                var resParam = parametersGrid.SelectedItems[0] as ResourceParameters;

                if (resParam == null)
                    return;

                var dialog = new ResourceParameterEditWindow(resParam);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        db.ResourceParameters_Update(resParam.ResourceParameterId, resParam.Value);

                        parametersGrid.ItemsSource = null;
                        parametersGrid.ItemsSource = db.ResourceParameters.Where(rp => rp.ResourceId == Resource.ResourceId).Include(rp => rp.Resources).Include(rp => rp.ResourceParameterNames).ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Проверьте введённые значения");
                    }
                }
            }
        }
    }
}
