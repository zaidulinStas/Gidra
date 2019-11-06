using System.Windows;
using System.Collections.Generic;
using System;
using GidraSIM.Core.Model;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace GidraSIM.GUI.Core.BlocksWPF
{
    [DataContract]
    public class ProcedureWPF : SquareBlockWPF
    {
        public const int POINT_MARGIN = 7;

        //public int InputCount { get; set; } = 1;
        //public int OutputCount { get; set; } = 1;

        private int _inputCount = 1;
        public int InputCount
        {
            get { return _inputCount; }
            set {
                _inputCount = value;
                DrawPins();
            }
        }

        private int _outputCount = 1;
        public int OutputCount
        {
            get { return _outputCount; }
            set
            {
                _outputCount = value;
                DrawPins();
            }
        }

        //Входы обратной связи
        private List<ProcConnectionWPF> backInputs;

        //Выходы обратной связи
        private List<ProcConnectionWPF> backOutputs;

        //Входы
        private List<ProcConnectionWPF> inputs;

        // Выходы
        private List<ProcConnectionWPF> outputs;

        // Соединения с ресурсами
        private List<ResConnectionWPF> resputs;

        public Procedure BlockModel {  get; private set; }

        // константы для определения высоты блока

        public event Action OnInputsChanged;

        private List<UIElement> _pins = new List<UIElement>();

        public ProcedureWPF(Point position, Procedure block) : base(position, block.Name)
        {
            this.BlockModel = block;

            this.backInputs = new List<ProcConnectionWPF>();
            this.backOutputs = new List<ProcConnectionWPF>();
            this.outputs = new List<ProcConnectionWPF>();
            this.inputs = new List<ProcConnectionWPF>();
            this.resputs = new List<ResConnectionWPF>();

            DrawPins();
        }

        public void DrawPins()
        {
            foreach (var pin in _pins)
            {
                this.Children.Remove(pin);
            }

            _pins.Clear();

            // перерасчёт высоты блока
            int maxCount = Math.Max(this.InputCount, this.OutputCount);
            if (DEFAULT_HEIGHT < (2 * maxCount * POINT_MARGIN + 2 * RADIUS))
            {
                SetHeight(2 * maxCount * POINT_MARGIN + 2 * RADIUS);
            }

            // TODO: переписать код рисования точек
            // точки входа
            //MakePoint(inPointFill, DEFAULT_HEIGHT / 2, 0);
            double x = 0;
            double y = (GetHeight() / 2.0) - POINT_MARGIN * (this.InputCount - 1);

            for (int i = 0; i < this.InputCount; i++)
            {
                _pins.Add(new ConnectPointWPF(
                    new Point(x, y),
                    i,
                    InPointFill,
                    ConnectPointWPF_Type.inPut,
                    this));
                
                y += 2.0 * POINT_MARGIN;
            }

            // точка выхода
            //MakePoint(outPointFill, DEFAULT_HEIGHT / 2, DEFAULT_WIDTH);
            x = DEFAULT_WIDTH;
            y = (GetHeight() / 2.0) - POINT_MARGIN * (this.OutputCount - 1);
            for (int i = 0; i < this.OutputCount; i++)
            {
                _pins.Add(new ConnectPointWPF(
                    new Point(x, y),
                    i,
                    OutPointFill,
                    ConnectPointWPF_Type.outPut,
                    this));

                y += 2.0 * POINT_MARGIN;
            }

            x = 0;
            y = POINT_MARGIN;
            for (int i = 0; i < 1; i++)
            {
                _pins.Add(new ConnectPointWPF(
                    new Point(x, y),
                    i,
                    Brushes.Red,
                    ConnectPointWPF_Type.backInput,
                    this));
            }

            x = DEFAULT_WIDTH;
            y = POINT_MARGIN;
            for (int i = 0; i < 1; i++)
            {
                _pins.Add(new ConnectPointWPF(
                    new Point(x, y),
                    i,
                    Brushes.Red,
                    ConnectPointWPF_Type.backOutput,
                    this));
            }

            foreach (var pin in _pins)
            {
                this.Children.Add(pin);
            }
        }

        protected virtual void SetHeight(double height)
        {
            this.bodyGeometry.Rect = new Rect(new Size(DEFAULT_WIDTH, height));
        }

        protected virtual double GetHeight()
        {
            return this.bodyGeometry.Rect.Height;
        }

        protected override void UpdateConnectoins()
        {
            if (inputs != null)
            {
                foreach (ProcConnectionWPF connection in inputs)
                {
                    connection.Refresh();
                }
            }
            if (outputs != null)
            {
                foreach (ProcConnectionWPF connection in outputs)
                {
                    connection.Refresh();
                }
            }
            if (resputs != null)
            {
                foreach (ResConnectionWPF connection in resputs)
                {
                    connection.Refresh();
                }
            }
        }

        /// <summary>
        /// Добавить соединение на вход
        /// </summary>
        /// <param name="connectoin"></param>
        public void AddInPutConnection(ProcConnectionWPF connectoin)
        {
            inputs.Add(connectoin);
        }

        /// <summary>
        /// Добавить соединение на выход
        /////// </summary>
        /// <param name="connectoin"></param>
        public void AddOutPutConnection(ProcConnectionWPF connectoin)
        {
            outputs.Add(connectoin);
        }

        /// <summary>
        /// Добавить соединение с ресурсом
        /// </summary>
        /// <param name="connectoin"></param>
        public void AddResPutConnection(ResConnectionWPF connectoin)
        {
            resputs.Add(connectoin);
        }
        

        public override void RemoveConnection(ConnectionWPF connection)
        {
            if(connection is ProcConnectionWPF)
            {
                ProcConnectionWPF procConnection = connection as ProcConnectionWPF;

                inputs.Remove(procConnection);
                outputs.Remove(procConnection);
            }
            else if (connection is ResConnectionWPF)
            {
                ResConnectionWPF resConnection = connection as ResConnectionWPF;

                resputs.Remove(resConnection);
            }
        }

        public override void RemoveAllConnections()
        {
            if(inputs != null)
            {
                while (inputs.Count != 0)
                {
                    inputs[0].Remove();
                }
            }

            if (outputs != null)
            {
                while (outputs.Count != 0)
                {
                    outputs[0].Remove();
                }
            }

            if (resputs != null)
            {
                while (resputs.Count != 0)
                {
                    resputs[0].Remove();
                }
            }
        }
    }
}