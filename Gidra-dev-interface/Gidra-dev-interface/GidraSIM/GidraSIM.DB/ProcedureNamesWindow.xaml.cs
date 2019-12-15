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
    /// Interaction logic for ProcedureNamesWindow.xaml
    /// </summary>
    public partial class ProcedureNamesWindow : Window
    {
        SimSaprNewEntities db;

        public ProcedureNamesWindow()
        {
            InitializeComponent();

            db = new SimSaprNewEntities();
            db.ProcedureNames.Load();
            proceduresGrid.ItemsSource = db.ProcedureNames.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (proceduresGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < proceduresGrid.SelectedItems.Count; i++)
                {
                    var pName = proceduresGrid.SelectedItems[i] as ProcedureNames;
                    if (pName != null)
                    {
                        db.ProcedureNames.Remove(pName);
                    }
                }
            }
            db.SaveChanges();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            db.ProcedureNames_Create(tb_procName.Text);
            db.SaveChanges();
        }
    }
}
