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
                    Name = "Ввод описания печатной платы",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Объем данных для ввода", 10 },
                        { "Сложность платы", 2 },
                    },
                    ProgressFunction = "[x]/(100*[Объем данных для ввода] - 10*[Сложность платы] - 10*[Проектировщик.Скорость печати] - 10*[Проектировщик.Уровень владения компьютером] - 10*[Проектировщик.Объем знаний] - 30*[Процессор.Частота ЦПУ]/2000 -5*[Процессор.Количество ядер]-[Клавиатура.Удобство пользования])",
                },
                new Procedure()
                {
                    Name = "Компоновка конструктивного узла",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Количество элементов", 300 },
                        { "Количество конструктивных узлов", 4 },
                    },
                    ProgressFunction = "[x]/(1000*[Количество элементов]+200*[Количество конструктивных узлов] - 100*[Процессор.Частота ЦПУ]/1000 -100*[Процессор.Количество ядер] - 30*[Жесткий диск.Скорость работы]-2000*[САПР.Эффективность работы])",
                },
                new Procedure()
                {
                    Name = "Размещение элементов",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Количество элементов", 300 },
                        { "Число связей", 50 },
                        { "Площадь схемы", 100 },
                    },
                    ProgressFunction = "[x]/(1000*[Количество элементов]+200*[Число связей] - 10*[Площадь схемы] - 5*[Процессор.Частота ЦПУ]  - 2500*[Процессор.Количество ядер] - 200*[Жесткий диск.Скорость работы] - 1000*[САПР.Эффективность работы])",
                },
                new Procedure()
                {
                    Name = "Трассировка соединений",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Количество элементов", 300 },
                        { "Площадь схемы", 100 },
                        { "Число связей", 50 }
                    },
                    ProgressFunction = "[x]/(1000*[Количество элементов] + 200*[Число связей] - 10*[Площадь схемы] - 10*[Процессор.Частота ЦПУ]  - 1000*[Процессор.Количество ядер] - 20*[Жесткий диск.Скорость работы] - 10000*[САПР.Эффективность работы])",
                },
                new Procedure()
                {
                    Name = "Контроль качества выполнения",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Количество проверяемых характеристик", 100 }
                    },
                    ProgressFunction = "[x]/(100*[Количество проверяемых характеристик] - 10*[Проектировщик.Объем знаний])",
                },
                new Procedure()
                {
                    Name = "Подготовка документации",
                    Parameters = new Dictionary<string, double>
                    {
                        { "Объем документации", 10 }
                    },
                    ProgressFunction = "[x]/(100*[Объем документации] - [Жесткий диск.Скорость работы]/10 - 50*[Принтер.Скорость печати] - 10*[Проектировщик.Скорость печати] - 10*[Проектировщик.Объем знаний] - 10*[Проектировщик.Уровень владения компьютером])",
                },
                //new Procedure()
                //{
                //    Name = "Компоновка",
                //    Parameters = new Dictionary<string, double>
                //    {
                //        { "Число элементов", 30 },
                //        { "Число связей", 30 },
                //    },
                //    ProgressFunction = "[x]/([Число элементов]*200-[Компьютер.Частота процессора]/200-[Компьютер.RAM]*10)"
                //},
                //new Procedure()
                //{
                //    Name = "Трассировка",
                //    Parameters = new Dictionary<string, double>
                //    {
                //        { "Число элементов", 30 },
                //        { "Число связей", 30 },
                //    },
                //    ProgressFunction = "[x]/(([Число элементов] + [Число связей])*200-[Компьютер.Частота процессора]/200-[Компьютер.RAM]*10-[Проектировщик.Опыт работы]/10)"
                //},
                //new Procedure()
                //{
                //    Name = "Подготовка документации",
                //    Parameters = new Dictionary<string, double>
                //    {
                //        { "Объем докуменации", 100 },
                //    },
                //    ProgressFunction = "[x]/([Объем докуменации]*100-[Принтер.Скорость печати])"
                //},
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
