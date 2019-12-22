using GidraSIM.GUI.Core.BlocksWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public Dictionary<string, double> parameters;
        private Dictionary<string, TextBox> textBoxes;
        public string progressFunction;
        TextBox functionBox;
        public double? minQuality;
        public double? maxQuality;
        TextBox minQualityTextBox;
        TextBox maxQualityTextBox;
        public ProcedureWPF Procedure;

        public ParametersDialog()
        {
            InitializeComponent();
        }

        public ParametersDialog(Dictionary<string, double> paramsPairs, string _progressFunction, string title,
            double? _minQuality, double? _maxQuality, ProcedureWPF procedure)
        {
            InitializeComponent();

            DataContext = this;

            parameters = new Dictionary<string, double>();
            textBoxes = new Dictionary<string, TextBox>();
            progressFunction = _progressFunction;
            titleBlock.Text = title;
            Procedure = procedure;

            if (procedure != null && procedure.BlockName == "Логическое разветвление")
            {
                functionBox = new TextBox
                {
                    Name = "functionBox",
                    Text = "1",
                    Width = 400,
                    Margin = new Thickness(5, 0, 0, 4)
                };

                var inputsCount = new TextBox();
                inputsCount.Text = "1";
                inputsCount.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                inputsCount.IsReadOnly = true;
                inputsCount.Width = 400;
                inputsCount.Margin = new Thickness(5, 0, 0, 4);

                var inputsLabel = new Label();
                inputsLabel.Content = "Число входов";
                inputsLabel.Width = 400;
                inputsLabel.Margin = new Thickness(0, 0, 0, 2);
                inputsLabel.FontWeight = FontWeights.Bold;

                wrapPanel.Children.Add(inputsLabel);
                wrapPanel.Children.Add(inputsCount);

                var outputsCount = new TextBox();
                outputsCount.Text = 1.ToString();
                outputsCount.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                outputsCount.Width = 400;
                outputsCount.Margin = new Thickness(5, 0, 0, 4);
                outputsCount.TextChanged += (s, e) =>
                {
                    var textBox = s as TextBox;
                    procedure.OutputCount = int.Parse(textBox.Text.Length > 0 ? textBox.Text : "1");
                };

                var outputsLabel = new Label();
                outputsLabel.Content = "Число выходов";
                outputsLabel.Width = 400;
                outputsLabel.Margin = new Thickness(0, 0, 0, 2);
                outputsLabel.FontWeight = FontWeights.Bold;

                wrapPanel.Children.Add(outputsLabel);
                wrapPanel.Children.Add(outputsCount);
            }
            else if (procedure != null && procedure.BlockName == "Логическое слияние")
            {
                functionBox = new TextBox
                {
                    Name = "functionBox",
                    Text = "1",
                    Width = 400,
                    Margin = new Thickness(5, 0, 0, 4)
                };

                var inputsCount = new TextBox();
                inputsCount.Text = "1";
                inputsCount.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                inputsCount.Width = 400;
                inputsCount.Margin = new Thickness(5, 0, 0, 4);
                inputsCount.TextChanged += (s, e) =>
                {
                    var textBox = s as TextBox;
                    procedure.InputCount = int.Parse(textBox.Text.Length > 0 ? textBox.Text : "1");
                };

                var inputsLabel = new Label();
                inputsLabel.Content = "Число входов";
                inputsLabel.Width = 400;
                inputsLabel.Margin = new Thickness(0, 0, 0, 2);
                inputsLabel.FontWeight = FontWeights.Bold;

                wrapPanel.Children.Add(inputsLabel);
                wrapPanel.Children.Add(inputsCount);

                var outputsCount = new TextBox();
                outputsCount.Text = 1.ToString();
                outputsCount.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                outputsCount.Width = 400;
                outputsCount.IsReadOnly = true;
                outputsCount.Margin = new Thickness(5, 0, 0, 4);

                var outputsLabel = new Label();
                outputsLabel.Content = "Число выходов";
                outputsLabel.Width = 400;
                outputsLabel.Margin = new Thickness(0, 0, 0, 2);
                outputsLabel.FontWeight = FontWeights.Bold;

                wrapPanel.Children.Add(outputsLabel);
                wrapPanel.Children.Add(outputsCount);
            }
            else 
            {
                functionBox = new TextBox
                {
                    Name = "functionBox",
                    Text = _progressFunction,
                    Width = 400,
                    Height = 150,
                    TextWrapping = TextWrapping.Wrap,
                    AcceptsReturn = true,
                    Margin = new Thickness(5, 0, 0, 4)
                };

                if (_progressFunction != null)
                {
                    wrapPanel.Children.Add(new Label
                    {
                        Content = "Формула зависимости времени от параметров",
                        Width = 400,
                        Margin = new Thickness(0, 0, 0, 2),
                        FontWeight = FontWeights.Bold
                    });
                    wrapPanel.Children.Add(functionBox);
                }

                foreach (var paramsPair in paramsPairs)
                {
                    var textBox = new TextBox();
                    textBox.Text = string.IsNullOrEmpty(paramsPair.Value.ToString()) ? "0" : paramsPair.Value.ToString();
                    textBox.Width = 400;
                    textBox.Margin = new Thickness(5, 0, 0, 4);
                    textBoxes.Add(paramsPair.Key, textBox);

                    var label = new Label();
                    label.Content = paramsPair.Key;
                    label.Width = 400;
                    label.Margin = new Thickness(0, 0, 0, 2);
                    label.FontWeight = FontWeights.Bold;

                    wrapPanel.Children.Add(label);
                    wrapPanel.Children.Add(textBox);
                }
            }

            if (_minQuality.HasValue && _maxQuality.HasValue)
            {
                minQuality = _minQuality.Value;
                maxQuality = _maxQuality.Value;

                var minQualityTextBox = new TextBox();
                minQualityTextBox.Text = _minQuality.ToString();
                minQualityTextBox.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                minQualityTextBox.Width = 400;
                minQualityTextBox.Margin = new Thickness(5, 0, 0, 4);
                minQualityTextBox.Visibility = procedure.BlockName == "Логическое слияние" ? Visibility.Hidden : Visibility.Visible;
                this.minQualityTextBox = minQualityTextBox;

                var minQualityLabel = new Label();
                minQualityLabel.Content = "Минимальное качество";
                minQualityLabel.Width = 400;
                minQualityLabel.Margin = new Thickness(0, 0, 0, 2);
                minQualityLabel.FontWeight = FontWeights.Bold;
                minQualityLabel.Visibility = procedure.BlockName == "Логическое слияние" ? Visibility.Hidden : Visibility.Visible;

                wrapPanel.Children.Add(minQualityLabel);
                wrapPanel.Children.Add(minQualityTextBox);

                var maxQualityTextBox = new TextBox();
                maxQualityTextBox.Text = _maxQuality.ToString();
                maxQualityTextBox.Width = 400;
                maxQualityTextBox.PreviewTextInput += MinQualityTextBox_PreviewTextInput;
                maxQualityTextBox.Margin = new Thickness(5, 0, 0, 4);
                maxQualityTextBox.Visibility = procedure.BlockName == "Логическое разветвление" ? Visibility.Hidden : Visibility.Visible;
                this.maxQualityTextBox = maxQualityTextBox;

                var maxQualityLabel = new Label();
                maxQualityLabel.Content = "Максимальное качество";
                maxQualityLabel.Width = 400;
                maxQualityLabel.Margin = new Thickness(0, 0, 0, 2);
                maxQualityLabel.FontWeight = FontWeights.Bold;
                maxQualityLabel.Visibility = procedure.BlockName == "Логическое разветвление" ? Visibility.Hidden : Visibility.Visible;

                wrapPanel.Children.Add(maxQualityLabel);
                wrapPanel.Children.Add(maxQualityTextBox);
            }

            /*
             * У разветвления только Qвх
             * У слияния только Qвых
             */
        }

        private void MinQualityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in textBoxes)
            {
                parameters.Add(textBox.Key, Double.Parse(textBox.Value.Text));
            }
            progressFunction = functionBox.Text;
            if (minQuality.HasValue && maxQuality.HasValue)
            {
                minQuality = Double.Parse(minQualityTextBox.Text.Length > 0 ? minQualityTextBox.Text : "0");
                maxQuality = Double.Parse(maxQualityTextBox.Text.Length > 0 ? maxQualityTextBox.Text : "0");
            }
            this.DialogResult = true;
        }
    }
}
