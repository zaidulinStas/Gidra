using GidraSIM.DB.BaseProcedureParametersNamesWindows;
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

namespace GidraSIM.DB.BaseProceduresWindows
{
    /// <summary>
    /// Interaction logic for BaseProceduresWindow.xaml
    /// </summary>
    public partial class BaseProceduresWindow : Window
    {
        SimSaprNewEntities db;

        public BaseProceduresWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.BaseProcedures.Load();
            proceduresGrid.ItemsSource = db.BaseProcedures.ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var procedure = new BaseProcedures();
            var dialog = new BaseProcedureEditWindow(procedure);

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    db.BaseProcedures_Create(procedure.Name, procedure.DefaultFunctionExpression);

                    proceduresGrid.ItemsSource = null;
                    proceduresGrid.ItemsSource = db.BaseProcedures.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введённые значения");
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (proceduresGrid.SelectedItems.Count > 0)
            {
                var procedure = proceduresGrid.SelectedItems[0] as BaseProcedures;

                if (procedure == null)
                    return;

                var dialog = new BaseProcedureEditWindow(procedure);

                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        db.BaseProcedures_Update(procedure.BaseProcedureId, procedure.Name, procedure.DefaultFunctionExpression);

                        proceduresGrid.ItemsSource = null;
                        proceduresGrid.ItemsSource = db.BaseProcedures.ToList();
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
            if (proceduresGrid.SelectedItems.Count > 0)
            {
                var procedure = proceduresGrid.SelectedItems[0] as BaseProcedures;

                if (procedure == null)
                    return;

                db.ResourceTypes_Delete(procedure.BaseProcedureId);
                proceduresGrid.ItemsSource = null;
                proceduresGrid.ItemsSource = db.BaseProcedures.ToList();
            }
        }

        void btn_procNamePar_Click(object sender, RoutedEventArgs e)
        {
            var procedure = new BaseProcedures();

            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    procedure = row.Item as BaseProcedures;

                    break;
                }

            var dialog = new BaseProcedureParametersNamesWindow(procedure);
            dialog.ShowDialog();
        }
    }
}
