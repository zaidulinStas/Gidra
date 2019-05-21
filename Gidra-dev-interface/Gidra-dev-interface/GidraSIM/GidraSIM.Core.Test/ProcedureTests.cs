using GidraSIM.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GidraSIM.Core.Model.Tests
{
    [TestClass]
    public class ProcedureTests
    {
        [TestMethod]
        public void DatabaseTest()
        {
            var ef = new ProcedureService("asdsad");
            var items = ef.GetAll();
        }

        [TestMethod]
        public void ProcedureWithResources()
        {
            var computerResource = new Resource
            {
                Name = "Компьютер",
                MaxUsageCount = 1,
                Parameters = new Dictionary<string, double>
                {
                    { "Тактовая частота", 1900 },
                    { "Надёжность", 10 },
                }
            };

            var tracingProcedure = new Procedure()
            {
                Name = "Трассировка",
                Parameters = new Dictionary<string, double>
                {
                    { "Сложность", 2.5 },
                    { "Число элементов", 10 }
                },
                ProgressFunction = "[x]/" +
                "(20*[Сложность]" + //50
                "+100*[Число элементов]" + //1000
                "-10*[Человек.Профессионализм]" + //-100
                "-100*[Компьютер.Тактовая частота]/2400)",//-79.16
                //f(x)=[x]/870,84‬
                Resources = new List<Resource>
                {
                    computerResource,
                    new Resource
                    {
                        Name = "Человек",
                        MaxUsageCount = 1,
                        Parameters = new Dictionary<string, double>
                        {
                            { "Профессионализм", 10 },
                        }
                    }
                },
            };

            var processingResultsProcedure = new Procedure()
            {
                Name = "Обработка результатов",
                Parameters = new Dictionary<string, double>
                {
                    { "Объем данных", 10 },
                    { "Сложность расчётов", 10 }
                },
                ProgressFunction ="[x]/" +
                "(10*[Объем данных]" + //100
                "+20*[Сложность расчётов]" + //200
                "-4*[Принтер.Скорость печати]" +//-40
                "-100*[Компьютер.Тактовая частота]/2400" +
                "-20*rnd(-10,10))",//[-20, 20]

                //f(x)=[x]/180,84‬
                Resources = new List<Resource>
                {
                    computerResource,
                    new Resource
                    {
                        Name = "Принтер",
                        MaxUsageCount = 1,
                        Parameters = new Dictionary<string, double>
                        {
                            { "Скорость печати", 10 },
                            { "Надёжность", 10 },
                        }
                    },
                }
            };

            var connections = new List<Connection>
            {
                new Connection
                {
                    Begin = tracingProcedure,
                    End = processingResultsProcedure
                }
            };

            tracingProcedure.Inputs = new List<Connection> { new Connection { End = tracingProcedure } };
            tracingProcedure.Outputs = connections;

            processingResultsProcedure.Inputs= connections;
            processingResultsProcedure.Outputs = new List<Connection> { new Connection { Begin = processingResultsProcedure } };

            tracingProcedure.Inputs[0].Tokens.Enqueue(new Token());

            const int maxTime = 200000;
            double resultModelingTime = 0;
            for (int time = 0; time < maxTime; time++)
            {
                tracingProcedure.Update(time);
                processingResultsProcedure.Update(time);

                if (processingResultsProcedure.Outputs[0].Tokens.Any())
                {
                    resultModelingTime = time;
                    break;
                }
            }

            Assert.AreEqual(1052, resultModelingTime, 200);
            Assert.AreEqual(0, tracingProcedure.Inputs[0].Tokens.Count);
            Assert.AreEqual(0, tracingProcedure.Outputs[0].Tokens.Count);
            Assert.AreEqual(0, processingResultsProcedure.Inputs[0].Tokens.Count);
            Assert.AreEqual(1, processingResultsProcedure.Outputs[0].Tokens.Count);
        }
    }
}