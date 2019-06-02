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
        public ProcedureSelectionDialog()
        {

            InitializeComponent();
            listBox1.Items.Add(new Procedure()
            {
                Name = "Сбор исходных данных",
                Parameters = new Dictionary<string, double>
                {
                    { "Объем данных", 10 },
                },
                ProgressFunction = "[x]/([Объем данных]*100)",
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Создание библиотеки компонентов",
                Parameters = new Dictionary<string, double>
                {
                    { "Число компонентов", 1000 },
                },
                ProgressFunction = "[x]/([Число компонентов]*10-[Компьютер.RAM]*10)",
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Компоновка",
                Parameters = new Dictionary<string, double>
                {
                    { "Число элементов", 30 },
                },
                ProgressFunction = "[x]/([Число элементов]*200-[Компьютер.Частота процессора]/2000*10-[Компьютер.RAM]*10)"
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Размещение",
                Parameters = new Dictionary<string, double>
                {
                    { "Число элементов", 10 },
                    { "Сложность связей", 40 },
                },
                ProgressFunction = "[x]/([Число элементов]*200 + [Сложность связей]*200-[Компьютер.Частота процессора]/2000*10-[Компьютер.RAM]*10)"
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Трассировка",
                Parameters = new Dictionary<string, double>
                {
                    { "Число элементов", 10 },
                    { "Сложность связей", 40 },
                },
                ProgressFunction = "[x]/([Число элементов]*200 + [Сложность связей]*200-[Компьютер.Частота процессора]/2000*10-[Компьютер.RAM]*10)"
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Моделирование",
                Parameters = new Dictionary<string, double>
                {
                    { "Число элементов", 10 },
                    { "Сложность связей", 40 },
                },
                ProgressFunction = "[x]/([Число элементов]*200 + [Сложность связей]*200-[Компьютер.Частота процессора]/2000*100-[Компьютер.RAM]*10)"
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Верификация",
                Parameters = new Dictionary<string, double>
                {
                    { "Объем данных", 100 },
                },
                ProgressFunction = "[x]/([Объем данных]*100 - [Нормоконтролер.Опыт работы]*2)",
            });
            listBox1.Items.Add(new Procedure()
            {
                Name = "Выпуск документации",
                Parameters = new Dictionary<string, double>
                {
                    { "Объем данных", 100 },
                },
                ProgressFunction = "[x]/([Объем данных]*100 - [Принтер.Скорость печати]*10)",
            });


            //listBox1.Items.Add(new Procedure()
            //{
            //    Name = "Обработка результатов",
            //    Parameters = new Dictionary<string, double>
            //    {
            //        { "Объем данных", 10 },
            //        { "Сложность расчётов", 10 }
            //    },
            //    ProgressFunction = "[x]/" +
            //    "(10*[Объем данных]" + //100
            //    "+20*[Сложность расчётов]" + //200
            //    "-4*[Принтер.Скорость печати]" +//-40
            //    "-100*[Компьютер.Тактовая частота]/2400" +
            //    "-20*rnd(-10,10))",//[-20, 20]
            //});
            //listBox1.Items.Add(new Procedure()
            //{
            //    Name = "Трассировка",
            //    Parameters = new Dictionary<string, double>
            //    {
            //        { "Сложность", 2.5 },
            //        { "Число элементов", 10 }
            //    },
            //    ProgressFunction = "[x]/" +
            //    "(20*[Сложность]" + //50
            //    "+100*[Число элементов]" + //1000
            //    "-10*[Человек.Профессионализм]" + //-100
            //    "-100*[Компьютер.Тактовая частота]/2400)",//-79.16
            //    //f(x)=[x]/870,84‬
            //});

            this.button.Focus();
            listBox1.SelectedIndex = 0;
        }

        public Procedure SelectedBlock { get; private set; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SelectedBlock = listBox1.SelectedItem as Procedure;
            listBox1.Items.Remove(listBox1.SelectedItem);
            this.DialogResult = true;
        }
    }
}
