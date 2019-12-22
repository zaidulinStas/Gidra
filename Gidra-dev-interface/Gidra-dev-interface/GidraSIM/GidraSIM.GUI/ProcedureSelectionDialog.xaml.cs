using System.Collections.Generic;
using System.Windows;
using GidraSIM.Core.Model;

namespace GidraSIM.GUI
{
    /// <summary>
    /// Логика взаимодействия для TestProcedureSelectionDialog.xaml
    /// </summary>
    public partial class ProcedureSelectionDialog : Window
    {
        public Procedure SelectedBlock { get; private set; }

        public Procedure[] Blocks { get; set; }

        public ProcedureSelectionDialog()
        {
            Blocks = new[]
            {
                new Procedure()
                {
                    Name = "Сбор исходных данных",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Объем данных", 10 },
                    },
                    ProgressFunction = "[x]/([Объем данных]*100-[Проектировщик.Объем знаний]/10)",
                },
                new Procedure()
                {
                    Name = "Создание библиотеки компонентов",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Число компонентов", 1000 },
                    },
                    ProgressFunction = "[x]/([Число компонентов]*10-[Компьютер.RAM]*10)",
                },
                new Procedure()
                {
                    Name = "Компоновка",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Число элементов", 30 },
                        { "Число связей", 30 },
                    },
                    ProgressFunction = "[x]/([Число элементов]*200-[Компьютер.Частота процессора]/200-[Компьютер.RAM]*10)"
                },
                new Procedure()
                {
                    Name = "Трассировка",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Число элементов", 30 },
                        { "Число связей", 30 },
                    },
                    ProgressFunction = "[x]/(([Число элементов] + [Число связей])*200-[Компьютер.Частота процессора]/200-[Компьютер.RAM]*10-[Проектировщик.Опыт работы]/10)"
                },
                new Procedure()
                {
                    Name = "Размещение",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Число элементов", 30 },
                        { "Число связей", 30 },
                    },
                    ProgressFunction = "[x]/(([Число элементов] + [Число связей])*200-[Компьютер.Частота процессора]/200-[Компьютер.RAM]*10-[Проектировщик.Опыт работы]/10)"
                },
                new Procedure()
                {
                    Name = "Подготовка документации",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Объем докуменации", 100 },
                    },
                    ProgressFunction = "[x]/([Объем докуменации]*100-[Принтер.Скорость печати])"
                },
                new OneToManyProcedure()
                {
                    Name = "Логическое разветвление",
                    ProgressFunction = "[x]"
                },
                new ManyToOneProcedure()
                {
                    Name = "Логическое слияние",
                    ProgressFunction = "[x]"
                }
            };

            DataContext = this;

            InitializeComponent();

            this.button.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //SelectedBlock = listBox1.SelectedItem as Procedure;
            //listBox1.Items.Remove(listBox1.SelectedItem);
            DialogResult = true;
        }
    }
}
