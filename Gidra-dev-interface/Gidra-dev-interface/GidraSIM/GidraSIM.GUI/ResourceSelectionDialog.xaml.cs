﻿using GidraSIM.Core.Model;
using System.Collections.Generic;
using System.Windows;

namespace GidraSIM.GUI
{
    /// <summary>
    /// Логика взаимодействия для TestResourceSelectionDialog.xaml
    /// </summary>
    public partial class ResourceSelectionDialog : Window
    {
        public ResourceSelectionDialog()
        {
            InitializeComponent();
            listView1.Items.Add(new Resource
            {
                Name = "Компьютер",
                Type = "Компьютер",
                MaxUsageCount = 1,
                Parameters = new Dictionary<string, double>
                {
                    { "Тактовая частота", 1900 },
                    { "Надёжность", 10 },
                }
            });
            listView1.Items.Add(new Resource
            {
                Name = "Вася",
                Type = "Человек",
                MaxUsageCount = 1,
                Parameters = new Dictionary<string, double>
                        {
                            { "Профессионализм", 10 },
                        }
            });
            listView1.Items.Add(new Resource
            {
                Name = "Canon 12SX",
                Type = "Принтер",
                MaxUsageCount = 1,
                Parameters = new Dictionary<string, double>
                        {
                            { "Скорость печати", 10 },
                            { "Надёжность", 10 },
                        }
            });
            listView1.SelectedIndex = 0;
            SelectedResource = new Resource();
            this.button.Focus();
        }

        public Resource SelectedResource { get; private set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SelectedResource = listView1.SelectedItem as Resource;
            listView1.Items.Remove(listView1.SelectedItem);
            this.DialogResult = true;
        }
    }
}