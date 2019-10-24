﻿using System;
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
        public Dictionary<string, double> parameters;
        private Dictionary<string, TextBox> textBoxes;
        public string progressFunction;
        TextBox functionBox;

        public ParametersDialog()
        {
            InitializeComponent();
        }

        public ParametersDialog(Dictionary<string, double> paramsPairs, string _progressFunction, string title)
        {
            InitializeComponent();

            parameters = new Dictionary<string, double>();
            textBoxes = new Dictionary<string, TextBox>();
            progressFunction = _progressFunction;

            titleBlock.Text = title;

            functionBox = new TextBox
            {
                Name = "functionBox",
                Text = _progressFunction,
                Width = 200,
                Margin = new Thickness(5, 0, 0, 4)
            };

            if (_progressFunction != null)
            {
                wrapPanel.Children.Add(new Label
                {
                    Content = "Функция",
                    Width = 200,
                    Margin = new Thickness(0, 0, 0, 2),
                    FontWeight = FontWeights.Bold
                });
                wrapPanel.Children.Add(functionBox);
            }

            foreach (var paramsPair in paramsPairs)
            {
                var textBox = new TextBox();
                textBox.Text = string.IsNullOrEmpty(paramsPair.Value.ToString()) ? "0" : paramsPair.Value.ToString();
                textBox.Width = 200;
                textBox.Margin = new Thickness(5, 0, 0, 4);
                textBoxes.Add(paramsPair.Key, textBox);

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
                parameters.Add(textBox.Key, Double.Parse(textBox.Value.Text));
            }
            progressFunction = functionBox.Text;
            this.DialogResult = true;
        }
    }
}