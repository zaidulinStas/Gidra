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

namespace GidraSIM.DB.BaseProcedureParametersNamesWindows
{
    /// <summary>
    /// Interaction logic for BaseProcedureParametersNamesWindow.xaml
    /// </summary>
    public partial class BaseProcedureParametersNamesWindow : Window
    {
        SimSaprNewEntities db;
        BaseProcedures BaseProcedure;

        public BaseProcedureParametersNamesWindow(BaseProcedures baseProcedure)
        {
            InitializeComponent();
            BaseProcedure = baseProcedure;

            db = new SimSaprNewEntities();
            db.BaseProcedureParameterNames.Load();
            parametersGrid.ItemsSource = db.BaseProcedureParameterNames.Where(p => p.BaseProcedureId == BaseProcedure.BaseProcedureId).ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var procParamName = new BaseProcedureParameterNames();
            var dialog = new BaseProcedureParameterNameEditWindow(procParamName);

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    db.BaseProcedureParameterNames_Create(procParamName.Name, BaseProcedure.BaseProcedureId);

                    parametersGrid.ItemsSource = null;
                    parametersGrid.ItemsSource = db.BaseProcedureParameterNames.Where(p => p.BaseProcedureId == BaseProcedure.BaseProcedureId).ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введённые значения");
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (parametersGrid.SelectedItems.Count > 0)
            {
                var procParamName = parametersGrid.SelectedItems[0] as BaseProcedureParameterNames;

                if (procParamName == null)
                    return;

                var dialog = new BaseProcedureParameterNameEditWindow(procParamName);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        db.BaseProcedureParameterNames_Update(procParamName.BaseProcedureParameterNameId, procParamName.Name);

                        parametersGrid.ItemsSource = null;
                        parametersGrid.ItemsSource = db.BaseProcedureParameterNames.Where(p => p.BaseProcedureId == BaseProcedure.BaseProcedureId).ToList();
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
            if (parametersGrid.SelectedItems.Count > 0)
            {
                var procParamName = parametersGrid.SelectedItems[0] as BaseProcedureParameterNames;

                if (procParamName == null)
                    return;

                db.BaseProcedureParameterNames_Delete(procParamName.BaseProcedureParameterNameId);
                parametersGrid.ItemsSource = null;
                parametersGrid.ItemsSource = db.BaseProcedureParameterNames.Where(p => p.BaseProcedureId == BaseProcedure.BaseProcedureId).ToList();
            }
        }
    }
}
