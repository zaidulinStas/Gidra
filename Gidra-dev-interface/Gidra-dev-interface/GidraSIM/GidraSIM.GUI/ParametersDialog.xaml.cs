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

        public ParametersDialog(string[] paramsNames)
        {
            InitializeComponent();

            parameters = new Dictionary<string, string>();
            textBoxes = new List<TextBox>();

            foreach (var paramsName in paramsNames)
            {
                var textBox = new TextBox();
                textBox.Text = "";
                textBox.Name = paramsName;
                textBox.Width = 200;
                textBox.Margin = new Thickness(0, 0, 0, 8);
                textBoxes.Add(textBox);

                var label = new Label();
                label.Content = paramsName;
                label.Margin = new Thickness(0, 0, 5, 8);

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
