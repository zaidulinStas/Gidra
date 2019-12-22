using GidraSIM.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GidraSIM.GUI
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public SimulationLog[] Logs { get; set; } = new SimulationLog[0];

        public string TotalTime { get; set; }

        public string TotalCost { get; set; }

        public ResultWindow(double totalTime, double totalCost, SimulationLog[] logs)
        {
            InitializeComponent();

            TotalTime = totalTime.ToString();
            TotalCost = totalCost.ToString() + " руб.";

            foreach (var log in logs)
            {
                log.Procedure = new Procedure() { Name = log.Procedure.Name };
                log.SimulationResult.StartQuality = Math.Floor(log.SimulationResult.StartQuality * 100.0);
                log.SimulationResult.ResultQuality = Math.Floor(log.SimulationResult.ResultQuality * 100.0);
            }

            Logs = logs;

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
