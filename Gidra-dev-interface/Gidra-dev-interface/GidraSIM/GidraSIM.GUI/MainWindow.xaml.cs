using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GidraSIM.GUI.Core.BlocksWPF;
using GidraSIM.Core.Model;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace GidraSIM.GUI
{
    public enum Theme { Classic, Dark }

    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Theme theme;
        private string savePath = "";

        //переменная для именования процессов (симуляторов)
        int processNamesCounter = 1;
        SimulationOptions mainProcess = new SimulationOptions();
        int mainProcessNumber;

        List<SimulationOptions> processes = new List<SimulationOptions>();
        List<DrawArea> drawAreas = new List<DrawArea>();

        /// <summary>
        /// сложность начальной задачи
        /// </summary>
        double complexity = 10;

        /// <summary>
        /// шаг моделирования
        /// </summary>
        double dt = 1;

        /// <summary>
        /// максимальное время моделирования
        /// </summary>
        double maxTime = 1000;

        Brush imageBackground;

        public MainWindow()
        {
            InitializeComponent();

            // Стандартные команды
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, NewProjectItemMenu_Click));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Save_Click));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, Open_Click));
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, Delete_Executed));

            // Кастомные команды
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.Arrow, Arrow_Executed));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.Procedure, Procedure_Executed));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.Resourse, Resourse_Executed));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.Connect, Connect_Executed));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.SubProcess, SubProcess_Executed));
            //this.CommandBindings.Add(new CommandBinding(MainWindowCommands.StartCheck, StartCheck_Executed));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.StartModeling, StartModeling_Executed));


            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.BlackTheme, DarkThemeMenuItem_Click));
            this.CommandBindings.Add(new CommandBinding(MainWindowCommands.WhiteTheme, ClassicThemeMenuItem_Click));

            imageBackground = DockPanel1.Background;


            theme = Theme.Classic;

            // Добавление первого процесса
            CreateNewProject();


            PushButton(button_arrow);
        }

        private void Delete_Executed(object sender, RoutedEventArgs e)//выбрали пункт меню Удалить
        {
            //берём от текущей вкладки
            var drawArea = (testTabControl.SelectedItem as TabItem).Content as DrawArea;
            drawArea.DeleteSelected();
        }

        /// <summary>
        /// Событие нажатия клавиши в режиме указатель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cursor_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        /*
        /// <summary>
        /// Событие нажатия клавиши в режиме процедура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Procedure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point cursorPoint = e.GetPosition(workCanvas);
            Point procedurePosition = (Point)(cursorPoint - new Point(ProcedureWPF.WIDTH / 2, ProcedureWPF.HEIGHT / 2));
            ProcedureWPF proc = new ProcedureWPF(procedurePosition, "Процедура");
            workCanvas.Children.Add(proc);
            MoveBlock(proc);
        }
        */
        private void MoveBlock(BlockWPF block)
        {
            Canvas.SetTop(block, block.Position.Y);
            Canvas.SetLeft(block, block.Position.X);
        }

        private void Procedure_Executed(object sender, RoutedEventArgs e)
        {
            if (drawAreas.First().Mode == Mode.Procedure)
            {
                SwitchToArrowMode();
            }
            else
            {
                SwitchTProcedureMode();
            }
        }

        private void SwitchTProcedureMode()
        {
            //меняем режим для всех на процедуры
            drawAreas.ForEach(area => area.SelectProcedureMode());

            PushButton(button_procedure);
        }

        private void Arrow_Executed(object sender, RoutedEventArgs e)
        {
            SwitchToArrowMode();
        }

        /// <summary>
        /// Реализация эффекта нажатой кнопки
        /// </summary>
        /// <param name="pushedButton">Кнопка, которую нужно нажать</param>
        private void PushButton(Button pushedButton)
        {
            // снятие выделения со всех кнопок
            foreach (var buttonObj in buttonPanel.Children)
            {
                if(buttonObj is Button)
                {
                    (buttonObj as Button).Effect = null;
                    (buttonObj as Button).Opacity = 1;
                }
            }

            // добавление выделения на pushedButton
            pushedButton.Effect = new BlurEffect() { Radius = 4 };
            pushedButton.Opacity = 0.8;
        }

        private void SwitchToArrowMode()
        {
            //меняем режим для всех на выделение
            drawAreas.ForEach(area => area.SelectArrowMode());

            PushButton(button_arrow);
        }

        private void Pr(object sender, MouseButtonEventArgs e)
        {

        }
        /// <summary>
        /// ресурс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resourse_Executed(object sender, RoutedEventArgs e)
        {
            if (drawAreas.First().Mode == Mode.Resourse)
            {
                SwitchToArrowMode();
            }
            else
            {
                SwitchToResourseMode();
            }
        }

        private void SwitchToResourseMode()
        {
            //меняем режим для всех на ресурсы
            drawAreas.ForEach(area => area.SelectResourseMode());

            PushButton(button_resourse);
        }


        /// <summary>
        /// связи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connect_Executed(object sender, RoutedEventArgs e)
        {
            if (drawAreas.First().Mode == Mode.Connect)
            {
                SwitchToArrowMode();
            }
            else
            {
                SwitchToConnectMode();
            }
        }

        private void SwitchToConnectMode()
        {
            //меняем для всех на связи
            drawAreas.ForEach(area => area.SelectConnectMode());

            PushButton(button_connect);
        }

        /// <summary>
        /// подпроцесс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubProcess_Executed(object sender, RoutedEventArgs e)
        {
            if (drawAreas.First().Mode == Mode.SubProcess)
            {
                SwitchToArrowMode();
            }
            else
            {
                SwitchToSubProcessMode();
            }
        }

        private void SwitchToSubProcessMode()
        {
            //меняем для всех на подпроцессы
            drawAreas.ForEach(area => area.SelectSubProcessMode());

            //PushButton(button_SubProcess);
        }

        //public void Map(UIElementCollection uIElementCollection, SimulationOptions simOptions)
        //{
        //    Dictionary<ProcedureWPF, Procedure> procedures = new Dictionary<ProcedureWPF, Procedure>();
        //    Dictionary<ResourceWPF, Resource> resources = new Dictionary<ResourceWPF, Resource>();

        //    var resultProcedures = new List<Procedure>();

        //    foreach (var element in uIElementCollection)
        //    {
        //        //смотрим все соединения процедур
        //        if (element is ProcConnectionWPF)
        //        {
        //            var connection = (element as ProcConnectionWPF);

        //            //TODO типа можно здесь всё обработать
        //            // Комментарий от 28.05.19: facepalm
        //            if (connection.StartBlock is StartBlockWPF && connection.EndBlock is EndBlockWPF)
        //            {
        //                throw new Exception("Нельзя просто соединить начало с концом!");
        //            }

        //            //обработка стартового блока
        //            if (connection.StartBlock is StartBlockWPF)
        //            {
        //                Procedure block;

        //                //если в первый раз встерчаем блок
        //                if (!(procedures.ContainsKey(connection.EndBlock as ProcedureWPF)))
        //                {
        //                    //первого нет, второй значимый
        //                    block = (connection.EndBlock as ProcedureWPF).BlockModel;

        //                    //добавляем его в список
        //                    procedures.Add(connection.EndBlock as ProcedureWPF, block);

        //                    //добавляем его в список всех блоков процесса
        //                    resultProcedures.Add(block);
        //                }
        //                //иначе просто берём из базы
        //                else
        //                    block = procedures[connection.EndBlock as ProcedureWPF];

        //                //process.StartBlock = block;
        //                //соединение будет когда-то потом
        //            }
        //            //обработка конечного блока
        //            else if (connection.EndBlock is EndBlockWPF)
        //            {
        //                Procedure block = null;

        //                //если в первый раз такое встречаем
        //                if (!(procedures.ContainsKey(connection.StartBlock as ProcedureWPF)))
        //                {
        //                    block = (connection.StartBlock as ProcedureWPF).BlockModel;
        //                    procedures.Add(connection.StartBlock as ProcedureWPF, block);
        //                    resultProcedures.Add(block);
        //                }
        //                else
        //                {
        //                    block = procedures[connection.StartBlock as ProcedureWPF];
        //                }
        //                //process.EndBlock = block;
        //                //соединение будет когда-то потом
        //            }
        //            //обработка всех остальных блоков
        //            else
        //            {
        //                Procedure block = null;

        //                //если в первый раз такое встречаем
        //                if (!(procedures.ContainsKey(connection.StartBlock as ProcedureWPF)))
        //                {
        //                    block = (connection.StartBlock as ProcedureWPF).BlockModel;
        //                    procedures.Add(connection.StartBlock as ProcedureWPF, block);
        //                    resultProcedures.Add(block);
        //                }
        //                //если в первый раз такое встречаем
        //                if (!(procedures.ContainsKey(connection.EndBlock as ProcedureWPF)))
        //                {
        //                    block = (connection.EndBlock as ProcedureWPF).BlockModel;
        //                    procedures.Add(connection.EndBlock as ProcedureWPF, block);
        //                    resultProcedures.Add(block);
        //                }


        //                //к счастью там только один вход и выход
        //                //process.Connections.Connect(procedures[connection.StartBlock as ProcedureWPF], connection.StartPort,
        //                //    procedures[connection.EndBlock as ProcedureWPF], connection.EndPort);

        //            }
        //        }
        //        //сотрим соединения ресурсов
        //        else if (element is ResConnectionWPF)
        //        {

        //            var connection = (element as ResConnectionWPF);
        //            ProcedureWPF procedure;
        //            ResourceWPF resourceWPF;
        //            if (connection.StartBlock is ProcedureWPF)
        //            {
        //                procedure = connection.StartBlock as ProcedureWPF;
        //                resourceWPF = connection.EndBlock as ResourceWPF;
        //            }
        //            else
        //            {
        //                procedure = connection.EndBlock as ProcedureWPF;
        //                resourceWPF = connection.StartBlock as ResourceWPF;
        //            }
        //            Procedure block = null;

        //            //если в первый раз такое встречаем
        //            if (!(procedures.ContainsKey(procedure)))
        //            {
        //                block = procedure.BlockModel;
        //                procedures.Add(procedure, block);
        //                resultProcedures.Add(block);
        //            }
        //            else
        //                block = procedures[procedure];

        //            Resource resource = null; ;
        //            //если в первый раз такое встречаем
        //            if (!(resources.ContainsKey(resourceWPF)))
        //            {
        //                resource = this.ConvertWpfResourceToModel(resourceWPF);
        //                resources.Add(resourceWPF, resource);
        //                //process.Resources.Add(resource); // WTF???
        //            }
        //            else
        //                resource = resources[resourceWPF];

        //            if (block is Procedure)
        //                (block as Procedure).Resources.Add(resource);
        //            else
        //                throw new ArgumentException("Ресурсы поддерживает только блоки типа Procedure");
        //        }
        //    }

        //    simOptions.Procedures = resultProcedures;
        //}

        private void StartModeling_Executed(object sender, RoutedEventArgs e)
        {
            try
            {
                var tabs = testTabControl.Items.OfType<TabItem>().ToList();
                var drawArea = tabs[0].Content as DrawArea;

                var proceduresConnections = drawArea.Children.OfType<ProcConnectionWPF>()
                    .Where(x => x.startPoint == null || x.startPoint.ConnectType == ConnectPointWPF_Type.outPut)
                    .ToList();
                var backLinksConnections = drawArea.Children.OfType<ProcConnectionWPF>()
                    .Where(x => x.startPoint != null && x.startPoint.ConnectType == ConnectPointWPF_Type.backOutput)
                    .ToList();
                var resourcesConnections = drawArea.Children.OfType<ResConnectionWPF>().ToList();
                var procedures = drawArea.Children.OfType<ProcedureWPF>().ToList();
                var resources = drawArea.Children.OfType<ResourceWPF>().ToList();

                var resourcesDictionary = resourcesConnections
                    .Select(x => new
                    {
                        Connection = x,
                        Resource = x.StartBlock is ResourceWPF ? x.StartBlock as ResourceWPF : x.EndBlock as ResourceWPF,
                        Procedure = x.StartBlock is ProcedureWPF ? x.StartBlock as ProcedureWPF : x.EndBlock as ProcedureWPF
                    })
                    .GroupBy(x => x.Procedure)
                    .ToDictionary(x => x.Key.BlockModel, x => x.Select(y => y.Resource).ToList());

                var proceduresDictionary = proceduresConnections
                    .Where(x => x.StartBlock as ProcedureWPF != null && x.EndBlock as ProcedureWPF != null)
                    .Select(x => new
                    {
                        StartProcedure = x.StartBlock as ProcedureWPF,
                        EndProcedure = x.EndBlock as ProcedureWPF
                    })
                    .Select(x => new
                    {
                        Connection = new Connection()
                        {
                            Begin = x.StartProcedure.BlockModel,
                            End = x.EndProcedure.BlockModel
                        },
                        x.StartProcedure,
                        x.EndProcedure
                    })
                    .ToList();

                var proceduresBackLinkDictionary = backLinksConnections
                    .Select(x => new
                    {
                        StartProcedure = x.StartBlock as ProcedureWPF,
                        EndProcedure = x.EndBlock as ProcedureWPF
                    })
                    .Select(x => new
                    {
                        Connection = new Connection()
                        {
                            Begin = x.StartProcedure.BlockModel,
                            End = x.EndProcedure.BlockModel
                        },
                        x.StartProcedure,
                        x.EndProcedure
                    })
                    .ToList();

                var allProcedures = new List<Procedure>();
                allProcedures.AddRange(proceduresDictionary.SelectMany(x => new[] { x.Connection.Begin, x.Connection.End }).Cast<Procedure>());
                allProcedures.AddRange(proceduresBackLinkDictionary.SelectMany(x => new[] { x.Connection.Begin, x.Connection.End }).Cast<Procedure>());
                allProcedures.AddRange(resourcesDictionary.Keys.Select(x => x));

                var totalProcedures = allProcedures.Distinct();
                foreach (var procedure in totalProcedures)
                {
                    procedure.Resources = resourcesDictionary.ContainsKey(procedure) ? resourcesDictionary[procedure].Select(res => res.ResourceModel).ToList() : new List<Resource>();
                    procedure.Inputs = proceduresDictionary.Where(x => x.EndProcedure.BlockModel == procedure).Select(x => x.Connection).ToList();
                    procedure.Outputs = proceduresDictionary.Where(x => x.StartProcedure.BlockModel == procedure).Select(x => x.Connection).ToList();
                    procedure.BackLinks = proceduresBackLinkDictionary.Where(x => x.StartProcedure.BlockModel == procedure).Select(x => x.Connection).ToList();
                }

                var options = new SimulationOptions()
                {
                    Procedures = totalProcedures
                    .Cast<BaseProcedure>()
                    .ToList()
                };

                var simulator = new Simulator();

                var results = simulator.Simulate(options);

                var successString = results.IsSuccess ? "успешно" : "неудачно";
                string resultMsg = $"Моделирование завершено {successString}";

                if (results.IsSuccess)
                {
                    resultMsg += $"{Environment.NewLine}Время моделирования: {results.ModelingTime}";

                    foreach (var log in results.Logs.Where(log => !string.IsNullOrEmpty(log.Procedure.Name)))
                    {
                        resultMsg += $"{Environment.NewLine}===" +
                            $"{Environment.NewLine}Процедура: {log.Procedure?.Name}" +
                            $"{Environment.NewLine}Начало: {log.SimulationResult.StartTime}" +
                            $"{Environment.NewLine}Продолжительность: {log.SimulationResult.Duration}" +
                            $"{Environment.NewLine}Конец: {log.SimulationResult.EndTime}" +
                            $"{Environment.NewLine}Качество: {(int)(log.SimulationResult.ResultQuality * 100.0)}";
                    }
                }

                MessageBox.Show(resultMsg);

                listBox1.Items.Clear();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                foreach (var process in processes)
                {
                    //process = new SimulationOptions();
                }
            }
        }


        private void CreateProcessButton_Click(object sender, RoutedEventArgs e)
        {
            ////создаём новый процесс
            //var process = new Process() { Description = "Процесс " + (++this.processNamesCounter) };
            ////добавляем в список всех процессов
            //processes.Add(process);
            ////надеюсь, что заголовок будет содержать название
            //var tabItem = new TabItem() { Header = process };
            ////переключаемся на новую вкладку, чтобы не было проблем с добавлением
            //testTabControl.SelectedItem = tabItem;
            ////теперь создаём область рисования
            //var drawArea = new DrawArea();
            ////добавляем ссылку на все ресурсы
            //drawArea.Processes = processes;
            //drawArea.Mode = drawAreas.First().Mode;
            ////добавляем в список
            //drawAreas.Add(drawArea);
            ////добавляем на вкладку
            //tabItem.Content = drawArea;
            ////и добавляем вкладку
            //testTabControl.Items.Add(tabItem);

            ////применение темы для новой вкладки
            //SetTheme();
        }

        private void testTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    MessageBox.Show("Selected tab " + (testTabControl.SelectedItem as TabItem).Header.ToString());
            //}
            //catch( InvalidOperationException )    
            //{
            //    //
            //}
            if (testTabControl.Items.Count > 0)
            {
                var drawArea = (testTabControl.SelectedItem as TabItem).Content as DrawArea;
                drawAreas.ForEach(area => area.Unsellect());
            }
            //drawAreas.ForEach(area => area.HideElements());

            //drawArea.ShowElements();

            //drawAreas.ForEach(area => area.UpdateLayout());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void ModelingParametersButton_Click(object sender, RoutedEventArgs e)
        {
            //ComplexitySelectionDialog dialog = new ComplexitySelectionDialog();
            //if (dialog.ShowDialog() == true)
            //{
            //    complexity = dialog.Complexity;
            //    dt = dialog.Step;
            //    maxTime = dialog.MaxTime;
            //}
        }
        private void SaveAsItemMenu_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void Save()
        {
            //try
            //{
            //    if (savePath.Count() != 0)
            //    {
            //        var saver = new ProjectSaver();
            //        saver.SaveProjectExecute(testTabControl, savePath, mainProcessNumber);
            //    }
            //    else SaveAs();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void SaveAs()
        {
            //try
            //{

            //    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            //    {
            //        FileName = "Project",
            //        DefaultExt = ".xml",
            //        Filter = "(XMl documents .xml)|*.xml"
            //    };

            //    if ((bool)dlg.ShowDialog())
            //    {
            //        var saver = new ProjectSaver();
            //        saver.SaveProjectExecute(testTabControl, dlg.FileName, mainProcessNumber);
            //        savePath = dlg.FileName;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Open()
        {
            //try
            //{
            //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            //    {
            //        FileName = "Project",
            //        DefaultExt = ".xml",
            //        Filter = "(XML documents .xml)|*.xml"
            //    };

            //    if (dlg.ShowDialog() == true)
            //    {
            //        this.savePath = dlg.FileName;

            //        ProjectSaver saver = new ProjectSaver();
            //        mainProcessNumber = saver.LoadProjectExecute(dlg.FileName, testTabControl, drawAreas, processes, out mainProcess);
            //        processNamesCounter = testTabControl.Items.Count;
            //        SetTheme();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ClassicThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //ClassicThemeMenuItem.IsChecked = true;
            //DarkThemeMenuItem.IsChecked = false;

            SetClassicTheme();
        }

        private void DarkThemeMenuItem_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ClassicThemeMenuItem_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void DarkThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //background FF2D2D30
            //2D2D30

            //ClassicThemeMenuItem.IsChecked = false;
            //DarkThemeMenuItem.IsChecked = true;

            SetDarkTheme();
        }

        private void SetClassicTheme()
        {

            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("classic.xaml", UriKind.Relative);

            // Динамически меняем коллекцию MergedDictionaries
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);


            //Background="#BBFFFFFF
            foreach (var tab in testTabControl.Items)
            {
                ((tab as TabItem).Content as DrawArea).workArea.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BBFFFFFF"));
            }
            //testTabControl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BBFFFFFF"));
            //DockPanel1.Background = imageBackground;
            //listBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BBFFFFFF"));
        }

        private void SetDarkTheme()
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("pack://application:,,,/Selen.Wpf.SystemStyles;component/Styles.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary myDictionary = new ResourceDictionary();
            myDictionary.Source = new Uri("dark.xaml", UriKind.Relative);
            //DockPanel1.Background = ;

            // Динамически меняем коллекцию MergedDictionaries
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            Application.Current.Resources.MergedDictionaries.Add(myDictionary);

            foreach (var tab in testTabControl.Items)
            {
                ((tab as TabItem).Content as DrawArea).workArea.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#252526"));
            }

            //DockPanel1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2D2D30"));
            //listBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#252526"));
        }

        private void SaveStatistic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new NotImplementedException("В разработке");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Statictics()
        {
            //using (FileStream stream = new FileStream($"tokens-log-{System.DateTime.Now.ToString("dd.MM.yyyy hh-mm-ss")}.xml", FileMode.Create))
            //{
            //    Type[] types = new Type[]
            //    {
            //    typeof(AndBlock),
            //    typeof(DuplicateOutputsBlock),
            //    typeof(CadResource),
            //    typeof(WorkerResource),
            //    typeof(TechincalSupportResource),
            //    typeof(MethodolgicalSupportResource),
            //    typeof(TokensCollector),
            //    typeof(ConnectionManager),
            //    typeof(ArrangementProcedure),
            //    typeof(Assembling),
            //    typeof(ClientCoordinationPrrocedure),
            //    typeof(DocumentationCoordinationProcedure),
            //    typeof(ElectricalSchemeSimulation),
            //    typeof(FixedTimeBlock),
            //    typeof(FormingDocumentationProcedure),
            //    typeof(Geometry2D),
            //    typeof(KDT),
            //    typeof(KinematicСalculations),
            //    typeof(PaperworkProcedure),
            //    typeof(QualityCheckProcedure),
            //    typeof(SampleTestingProcedure),
            //    typeof(SchemaCreationProcedure),
            //    typeof(StrengthСalculations),
            //    typeof(TracingProcedure),
            //    typeof(Process)
            //    };

            //    System.Runtime.Serialization.DataContractSerializer ser = new System.Runtime.Serialization.DataContractSerializer(typeof(TokensCollector), types);
            //    ser.WriteObject(stream, TokensCollector.GetInstance());
            //}
        }

        private void NewProjectItemMenu_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProject();
        }

        private void CreateNewProject()
        {
            // Устанавливаем дефолтные значения
            testTabControl.Items.Clear();
            drawAreas.Clear();
            processes.Clear();

            mainProcess = new SimulationOptions();
            mainProcessNumber = 0;
            processNamesCounter = 1;

            // Создаём процесс
            //Process process = new Process() { Description = mainProcess.Description };
            processes.Add(mainProcess); // Добавляем в список процессов

            var tabItem = new TabItem() { Header = mainProcess };
            testTabControl.SelectedItem = tabItem;

            // Создаём область рисования
            var drawArea = new DrawArea()
            {
                Processes = processes
            };

            drawAreas.Add(drawArea);
            tabItem.Content = drawArea;

            testTabControl.Items.Add(tabItem);

            SetTheme();
        }

        private void SetTheme()
        {
            switch (theme)
            {
                case Theme.Classic:
                    {
                        SetClassicTheme();
                        break;
                    }
                case Theme.Dark:
                    {
                        SetDarkTheme();
                        break;
                    }
            }
        }

        private void TokenViewerItemMenu_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    TokenViewer viewer = new TokenViewer();
            //    viewer.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
