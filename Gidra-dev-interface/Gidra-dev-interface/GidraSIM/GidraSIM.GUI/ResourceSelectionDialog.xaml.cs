using GidraSIM.Core.Model;
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
                Name = "Ноутбук MSIGL6QD",
                Type = "Компьютер",
                MaxUsageCount = 1,
                Cost = 70000,
                Parameters = new Dictionary<string, double>
                {
                    { "Частота процессора", 2100 },
                    { "RAM", 8 },
                }
            });
            listView1.Items.Add(new Resource
            {
                Name = "Ноутбук HP70",
                Type = "Компьютер",
                MaxUsageCount = 1,
                Cost = 30000,
                Parameters = new Dictionary<string, double>
                {
                    { "Частота процессора", 1200 },
                    { "RAM", 12 },
                }
            });
            listView1.Items.Add(new Resource
            {
                Name = "Ноутбук MAC",
                Type = "Компьютер",
                MaxUsageCount = 1,
                Cost = 100000,
                Parameters = new Dictionary<string, double>
                {
                    { "Частота процессора", 4000 },
                    { "RAM", 20 },
                }
            });


            listView1.Items.Add(new Resource
            {
                Name = "Canon mg2540s",
                Type = "Принтер",
                MaxUsageCount = 1,
                Cost = 6000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Скорость печати", 10 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Canon SS10",
                Type = "Принтер",
                MaxUsageCount = 1,
                Cost = 13000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Скорость печати", 50 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Проектировщик-новичок",
                Type = "Проектировщик",
                MaxUsageCount = 1,
                Cost = 20000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Объем знаний", 50 },
                            { "Опыт работы", 50 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Опытный проектировщик",
                Type = "Проектировщик",
                MaxUsageCount = 1,
                Cost = 40000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Объем знаний", 80 },
                            { "Опыт работы", 90 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Проектировщик-профессионал",
                Type = "Проектировщик",
                MaxUsageCount = 1,
                Cost = 100000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Объем знаний", 100 },
                            { "Опыт работы", 100 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "TopoR",
                Type = "САПР",
                MaxUsageCount = 1,
                Cost = 100000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Функционал", 50 },
                            { "Документация", 30 },
                        }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Allergo Cadence",
                Type = "САПР",
                MaxUsageCount = 1,
                Cost = 500000,
                Parameters = new Dictionary<string, double>
                        {
                            { "Функционал", 100 },
                            { "Документация", 70 },
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