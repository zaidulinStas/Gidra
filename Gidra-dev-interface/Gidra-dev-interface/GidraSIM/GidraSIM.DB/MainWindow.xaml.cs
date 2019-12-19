using GidraSIM.DB.ResourceTypesWindows;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GidraSIM.DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new ProcedureNamesWindow();
            //dialog.ShowDialog();
        }

        private void res_btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ResourceNamesWindow();
            dialog.ShowDialog();
        }

        private void res_param_btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ResourceParameterNamesWindow();
            dialog.ShowDialog();
        }

        private void res_type_btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ResourceTypesWindow();
            dialog.ShowDialog();
        }
    }
}
