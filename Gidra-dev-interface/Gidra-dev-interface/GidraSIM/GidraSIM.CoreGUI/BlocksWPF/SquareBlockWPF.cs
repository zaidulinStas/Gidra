using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace GidraSIM.GUI.Core.BlocksWPF
{
    /// <summary>
    /// Абстрактный класс для квадратных блоков
    /// </summary>
    [DataContract]
    public abstract class SquareBlockWPF : BlockWPF
    {
        // Константные параметры блока
        public const int DEFAULT_HEIGHT = 70;
        public const int DEFAULT_WIDTH = 150;
        public const int RADIUS = 5;

        protected const int TEXT_WIDTH = 90;
        protected const int TEXT_LEFT = 5;
        protected const int TEXT_TOP = 16;

        public Brush Fill { get; set; }
        public Brush InPointFill { get; set; }
        public Brush OutPointFill { get; set; }

        public string BlockName { get; private set; }

        public override Point MidPosition
        {
            get
            {
                return new Point(
                    Position.X + bodyPath.ActualWidth / 2,
                    Position.Y + bodyPath.ActualHeight / 2);
            }
        }

        public override Point LeftPosition
        {
            get
            {
                return new Point(
                    Position.X,
                    Position.Y + bodyPath.ActualHeight / 2);
            }
        }

        public override Point RightPosition
        {
            get
            {
                return new Point(
                    Position.X + bodyPath.ActualWidth,
                    Position.Y + bodyPath.ActualHeight / 2);
            }
        }

        public SquareBlockWPF(Point position, string squareBlockName) : base(position)
        {
            BlockName = squareBlockName;

            // построить заголовок
            this.MakeTitle(squareBlockName);
        }


        protected virtual void MakeTitle(string processName)
        {
            Border container = new Border();
            container.Width = DEFAULT_WIDTH;
            container.Height = DEFAULT_HEIGHT;
            container.Padding = new Thickness(4);
            container.BorderBrush = Brushes.Transparent;

            // подпись
            TextBlock processNameLabel = new TextBlock();
            processNameLabel.Text = processName;
            processNameLabel.TextWrapping = TextWrapping.Wrap;
            // processNameLabel.Width = DEFAULT_WIDTH;
            // processNameLabel.Height = DEFAULT_HEIGHT;
            processNameLabel.TextAlignment = TextAlignment.Center;
            processNameLabel.VerticalAlignment = VerticalAlignment.Center;
            processNameLabel.HorizontalAlignment = HorizontalAlignment.Stretch;
            processNameLabel.FontSize = 14;

            container.Child = processNameLabel;
            // позиция
            // Canvas.SetTop(processNameLabel, TEXT_TOP);
            // Canvas.SetLeft(processNameLabel, TEXT_LEFT);
            // добавление
            this.Children.Add(container);
        }

        /// <summary>
        /// path тела блока
        /// </summary>
        protected Path bodyPath;

        /// <summary>
        /// объект, отвечающий за геометрию тела блока
        /// </summary>
        protected RectangleGeometry bodyGeometry;

        protected override void MakeBody()
        {
            //костыль, переделаеть с помощью интерфейсов или ещё чего
            InPointFill = Brushes.Black;
            OutPointFill = Brushes.Green;
            Fill = Brushes.White;

            bodyPath = new Path();

            bodyPath.Stroke = Stroke;
            bodyPath.Fill = Fill;
            // содержимое path
            bodyGeometry = new RectangleGeometry(new Rect(new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT)), RADIUS, RADIUS);
            bodyPath.Data = bodyGeometry;
            // добавление
            this.Children.Add(bodyPath);
        }
    }
}
