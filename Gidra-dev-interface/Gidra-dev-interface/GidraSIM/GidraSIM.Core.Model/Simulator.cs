using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.Core.Model
{
    /// <summary>
    /// Основной класс, отвечающий за проведения всего процесса моделирования
    /// </summary>
    public class Simulator
    {
        /// <summary>
        /// Начальная процедура 
        /// </summary>
        public Procedure StartProcedure { get; private set; } = new Procedure()
        {
            Inputs = new[] { new Connection() },
            ProgressFunction = "1",
        };

        /// <summary>
        /// Конечная процедура 
        /// </summary>
        public Procedure EndProcedure { get; private set; } = new Procedure()
        {
            ProgressFunction = "1",
            Outputs = new [] { new Connection() }
        };

        /// <summary>
        /// Метод выполняет процесс моделирования 
        /// </summary>
        public SimulationResult Simulate(SimulationOptions options)
        {
            foreach (var procedure in options.Procedures.Where(x => !x.Inputs.Any()))
            {
                StartProcedure.Connect(procedure);
            }

            foreach (var procedure in options.Procedures.Where(x => !x.Outputs.Any()))
            {
                procedure.Connect(EndProcedure);
            }

            StartProcedure.Inputs[0].Tokens.Enqueue(options.StartToken);

            var activeProcedures = options.Procedures
                .Concat(new[] { StartProcedure, EndProcedure })
                .ToList();

            var logs = new List<SimulationLog>();

            double? modelingTime = null;
            for (double time = 0; time < options.MaxTime; time += options.SimulationStep)
            {
                var finishedProcedures = activeProcedures
                    .Select(x => new { Procedure = x, Result = x.Update(time) })
                    .Where(x => x.Result != null)
                    .ToList();

                logs.AddRange(finishedProcedures.Select(
                    x => new SimulationLog { Procedure = x.Procedure, SimulationResult = x.Result })
                );

                if (EndProcedure.Outputs[0].Tokens.Any())
                {
                    modelingTime = time;
                    break;
                }
            }

            foreach (var procedure in activeProcedures)
            {
                procedure.Flush();
            }

            return new SimulationResult
            {
                ModelingTime = modelingTime,
                TotalPrice = activeProcedures.Sum(p => p.AllResources.Sum(r => r.Cost)),
                //TotalPrice = activeProcedures
                //    .SelectMany(x => x.AllResources
                //        .SelectMany(res => res.Parameters)
                //        .Where(param => param.Key == "Стоимость")
                //        .Select(param => param.Value))
                //    .Sum(),
                Logs = logs
            };
        }
    }
}
