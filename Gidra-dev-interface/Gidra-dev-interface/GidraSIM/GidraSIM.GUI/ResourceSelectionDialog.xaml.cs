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
                Name = "Процессор AMD MD2",
                Type = "Процессор",
                MaxUsageCount = 1,
                Cost = 25000,
                Parameters = new Dictionary<string, double>
                {
                    { "Частота ЦПУ", 2500 },
                    { "Количество ядер", 2 },
                }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Клавиатура «HP transi-tion MX23»",
                Type = "Клавиатура",
                MaxUsageCount = 1,
                Cost = 2000,
                Parameters = new Dictionary<string, double>
                {
                    { "Удобство пользования", 4 },
                }
            });

            listView1.Items.Add(new Resource
            {
                Name = "Жесткий диск DEXP SP1",
                Type = "Жесткий диск",
                MaxUsageCount = 1,
                Cost = 5000,
                Parameters = new Dictionary<string, double>
                {
                    { "Скорость работы", 500 },
                }
            });

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
                            { "Уровень владения компьютером", 4},
                            { "Скорость печати", 5},
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
                            { "Скорость печати", 7},
                            { "Уровень владения компьютером", 7},
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
                            { "Уровень владения компьютером", 10},
                            { "Скорость печати", 9},
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
                            { "Эффективность работы", 5 },
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
                            { "Эффективность работы", 10 },
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