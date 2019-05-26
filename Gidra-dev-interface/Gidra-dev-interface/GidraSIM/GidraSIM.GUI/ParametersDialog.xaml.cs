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
using System.Windows.Shapes;

namespace GidraSIM.GUI
{
    /// <summary>
    /// Логика взаимодействия для ProcedureParametersDialog.xaml
    /// </summary>
    public partial class ParametersDialog : Window
    {
        public Dictionary<string, string> parameters;
        private List<TextBox> textBoxes;

        public ParametersDialog()
        {
            InitializeComponent();
        }

        public ParametersDialog(Dictionary<string, string> paramsPairs)
        {
            InitializeComponent();

            parameters = new Dictionary<string, string>();
            textBoxes = new List<TextBox>();

            foreach (var paramsPair in paramsPairs)
            {
                var textBox = new TextBox();
                textBox.Name = paramsPair.Key;
                textBox.Text = string.IsNullOrEmpty(paramsPair.Value) ? "0" : paramsPair.Value;
                textBox.Width = 200;
                textBox.Margin = new Thickness(5, 0, 0, 4);
                textBoxes.Add(textBox);

                var label = new Label();
                label.Content = paramsPair.Key;
                label.Width = 200;
                label.Margin = new Thickness(0, 0, 0, 2);
                label.FontWeight = FontWeights.Bold;
               
                wrapPanel.Children.Add(label);
                wrapPanel.Children.Add(textBox);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxes)
            {
                parameters.Add(textBox.Name, textBox.Text);
            }
            this.DialogResult = true;
        }
    }
}
