﻿using System;
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
        public Procedure StartProcedure { get; private set; } = new Procedure()
        {
            Inputs = new[] { new Connection() },
            ProgressFunction = "1",
        };

        public Procedure EndProcedure { get; private set; } = new Procedure()
        {
            ProgressFunction = "1",
            Outputs = new [] { new Connection() }
        };

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

            var activeProcedures = options.Procedures.Concat(new[] { StartProcedure, EndProcedure }).ToList();

            double? modelingTime = null;
            for (int time = 0; time < options.MaxTime; time++)
            {
                activeProcedures.ForEach(x => x.Update(time));

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
                ModelingTime = modelingTime
            };
        }
    }
}
