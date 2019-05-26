using GidraSIM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GidraSIM.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public ApplicationDbContext(string nameOrconnectionString) : base(nameOrconnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            if (db.Resources.Count() == 0)
            {
                if (db.Resources.FirstOrDefault(r => r.Name.Equals("Человек")) == null)
                {
                    var parameters = new List<Parameter>();
                    parameters.Add(new Parameter()
                    {
                        Key = "Уровень знаний и компетенций",
                        Value = 100
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Степень мотивации",
                        Value = 100
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Уровень навыков работы",
                        Value = 100
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Быстрообучаемость",
                        Value = 100
                    });
                    var human = new Resource()
                    {
                        Name = "Человек",
                        Parameters = parameters
                    };
                    db.Resources.Add(human);
                }

                if (db.Resources.FirstOrDefault(r => r.Name.Equals("САПР Компас")) == null)
                {
                    var parameters = new List<Parameter>();
                    parameters.Add(new Parameter()
                    {
                        Key = "Сложность системы",
                        Value = 100,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Полнота функциональности",
                        Value = 100,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Оптимальность алгоритмов",
                        Value = 100,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Простота интерфейса",
                        Value = 100,
                    });
                    var compas = new Resource()
                    {
                        Name = "САПР Компас",
                        Parameters = parameters
                    };
                    db.Resources.Add(compas);
                }

                if (db.Resources.FirstOrDefault(r => r.Name.Equals("Документация Компаса")) == null)
                {
                    var parameters = new List<Parameter>();
                    parameters.Add(new Parameter()
                    {
                        Key = "Понятность документации",
                        Value = 100,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Доступность документации",
                        Value = 100,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Полнота документации",
                        Value = 100,
                    });
                    var documents = new Resource()
                    {
                        Name = "Документация САПР",
                        Parameters = parameters
                    };
                    db.Resources.Add(documents);
                }

                if (db.Resources.FirstOrDefault(r => r.Name.Equals("Компьютер")) == null)
                {
                    var parameters = new List<Parameter>();
                    parameters.Add(new Parameter()
                    {
                        Key = "Процессор (частота, ГГц)",
                        Value = 3.6,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Процессор (количество ядер)",
                        Value = 8,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Видеокарта (частота графического процессора, МГц)",
                        Value = 1582,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Видеокарта (частота видеопамяти, МГц)",
                        Value = 8008,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Видеокарта (разрядность шины видеопамяти, bit)",
                        Value = 192,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Видеокарта (объем памяти, Гб)",
                        Value = 6,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Оперативная память (частота, МГц)",
                        Value = 2133,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Оперативная память (объем, Гб)",
                        Value = 4,
                    });
                    parameters.Add(new Parameter()
                    {
                        Key = "Принтер (скорость печати, зн/мин)",
                        Value = 1000,
                    });
                    var computer = new Resource()
                    {
                        Name = "Компьютер",
                        Parameters = parameters
                    };
                    db.Resources.Add(computer);
                }
            }

            base.Seed(db);
        }
    }
}

