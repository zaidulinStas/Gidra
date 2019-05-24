using GidraSIM.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var ef = new ProcedureService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GidraDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var items = ef.GetAll();
            try
            {
                ef.Create(new Procedure
                {
                    Name = "Трассировка",
                    ProgressFunction = "sadasds",
                    Parameters = new Dictionary<string, double>()
                    {
                        { "Производительность", 100 },
                        { "Стоимость", 100 },
                    }
                });
            }
            catch (Exception err)
            {
                int x = 0;
            }
        }

        [TestMethod]
        public void SimulatorTest()
        {
            var computerResource = new Resource
            {
                Name = "Компьютер",
                Type = "Компьютер",
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
                        Name = "Вася",
                        Type = "Человек",
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
                ProgressFunction = "[x]/" +
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
                        Name = "Canon 12SX",
                        Type = "Принтер",
                        MaxUsageCount = 1,
                        Parameters = new Dictionary<string, double>
                        {
                            { "Скорость печати", 10 },
                            { "Надёжность", 10 },
                        }
                    },
                }
            };

            tracingProcedure.Connect(processingResultsProcedure);

            var simulator = new Simulator();

            var results = simulator.Simulate(new SimulationOptions
            {
                Procedures = new List<Procedure> { tracingProcedure, processingResultsProcedure }
            });

            Assert.IsTrue(results.IsSuccess);
            Assert.AreEqual(1052, results.ModelingTime.Value, 200);
        }
    }
}