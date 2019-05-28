using GidraSIM.DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            ProcessorsSeed(db);
            GraphicsCardSeed(db);
            RAMSeed(db);
            HDDSeed(db);
            PrinterSeed(db);
            ScanerSeed(db);

            CADSeed(db);
            HelpSoftwareSeed(db);
            StandardsSeed(db);
            HumansSeed(db);

            base.Seed(db);
        }

        public void ProcessorsSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Процессор") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 2.4,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.4,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_1 = new Resource()
                {
                    Name = "Intel Core i7-4700MQ",
                    Parameters = parameters_1,
                    Cost = 24923,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4.4,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 18,
                });
                var processor_2 = new Resource()
                {
                    Name = "Intel Core i9-9980XE",
                    Parameters = parameters_1,
                    Cost = 180000,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 10,
                });
                var processor_3 = new Resource()
                {
                    Name = "Intel Core i7-6950X",
                    Parameters = parameters_3,
                    Cost = 47499,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.1,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.3,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_4 = new Resource()
                {
                    Name = "Intel Core i5-4440",
                    Parameters = parameters_4,
                    Cost = 10999,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 4,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4.2,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_5 = new Resource()
                {
                    Name = "Intel Core i7-6700K",
                    Parameters = parameters_5,
                    Cost = 22195,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 4,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4.3,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 8,
                });
                var processor_6 = new Resource()
                {
                    Name = "AMD FX-8370",
                    Parameters = parameters_6,
                    Cost = 8499,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_6);



                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 2.9,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 2.9,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 2,
                });
                var processor_7 = new Resource()
                {
                    Name = "AMD Athlon II X2 225",
                    Parameters = parameters_7,
                    Cost = 1455,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_7);

                var parameters_8 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.8,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.8,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 2,
                });
                var processor_8 = new Resource()
                {
                    Name = "Intel Pentium Gold G5500",
                    Parameters = parameters_8,
                    Cost = 7290,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_8);


                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 2,
                });
                var processor_9 = new Resource()
                {
                    Name = "Intel Core i3-4370",
                    Parameters = parameters_9,
                    Cost = 12925,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_9);


                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.5,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.7,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_10 = new Resource()
                {
                    Name = "AMD Ryzen 3 1300X",
                    Parameters = parameters_10,
                    Cost = 5510,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_10);



                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.6,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.9,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_11 = new Resource()
                {
                    Name = "AMD A8-7670K",
                    Parameters = parameters_11,
                    Cost = 5399,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_11);


                var parameters_12 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.6,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 5,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 8,
                });
                var processor_12 = new Resource()
                {
                    Name = "Intel Core i9-9900KF",
                    Parameters = parameters_12,
                    Cost = 38990,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_12);


                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.7,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 2,
                });
                var processor_13 = new Resource()
                {
                    Name = "AMD PRO A6-8550B",
                    Parameters = parameters_13,
                    Cost = 2590,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_13);


                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.6,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 4.3,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 6,
                });
                var processor_14 = new Resource()
                {
                    Name = "Intel Core i5-8600K",
                    Parameters = parameters_14,
                    Cost = 18440,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_14);


                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Частота, ГГц",
                    Value = 3.2,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Частота (Turbo), ГГц",
                    Value = 3.6,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Количество ядер",
                    Value = 4,
                });
                var processor_15 = new Resource()
                {
                    Name = "Intel Core i5-6500",
                    Parameters = parameters_15,
                    Cost = 12960,
                    Type = "Процессор"
                };
                db.Resources.Add(processor_15);
            }
        }

        public void GraphicsCardSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Видеокарта") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1770,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 14000,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 24,
                });
                var card_1 = new Resource()
                {
                    Name = "NVIDIA Titan RTX",
                    Parameters = parameters_1,
                    Cost = 269990,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1545,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 11000,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 14,
                });
                var card_2 = new Resource()
                {
                    Name = "NVIDIA GeForce RTX 2080 Ti",
                    Parameters = parameters_2,
                    Cost = 81877,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1800,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 2000,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 16,
                });
                var card_3 = new Resource()
                {
                    Name = "AMD Radeon VII",
                    Parameters = parameters_3,
                    Cost = 56390,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_3);



                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1582,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 11000,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 11,
                });
                var card_4 = new Resource()
                {
                    Name = "NVIDIA GeForce GTX 1080 Ti",
                    Parameters = parameters_4,
                    Cost = 58490,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 947,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 5000,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 4,
                });
                var card_5 = new Resource()
                {
                    Name = "AMD Radeon R9 290",
                    Parameters = parameters_5,
                    Cost = 19945,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 900,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 6008,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 3,
                });
                var card_6 = new Resource()
                {
                    Name = "Asus GeForce GTX 780",
                    Parameters = parameters_6,
                    Cost = 17970,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_6);


                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1455,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 7008,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 2,
                });
                var card_7 = new Resource()
                {
                    Name = "NVIDIA GeForce GTX 1050",
                    Parameters = parameters_7,
                    Cost = 8650,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_7);



                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1292,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 6000,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 4,
                });
                var card_8 = new Resource()
                {
                    Name = "AMD Radeon RX 560M",
                    Parameters = parameters_8,
                    Cost = 8920,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_8);


                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 700,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 1536,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 3,
                });
                var card_9 = new Resource()
                {
                    Name = "NVIDIA GeForce GTX 480",
                    Parameters = parameters_9,
                    Cost = 42894,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_9);


                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 750,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 4800,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 1,
                });
                var card_10 = new Resource()
                {
                    Name = "AMD Radeon HD 6930",
                    Parameters = parameters_10,
                    Cost = 10763,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_10);



                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 993,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 4000,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 4,
                });
                var card_11 = new Resource()
                {
                    Name = "NVIDIA GeForce GTX 950M",
                    Parameters = parameters_11,
                    Cost = 9690,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_11);

                var parameters_12 = new List<Parameter>();
                parameters_12.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1051,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 5012,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 8,
                });
                var card_12 = new Resource()
                {
                    Name = "PNY Quadro M5000M",
                    Parameters = parameters_12,
                    Cost = 172999,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_12);



                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 725,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 4000,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 4,
                });
                var card_13 = new Resource()
                {
                    Name = "Radeon HD 5970",
                    Parameters = parameters_13,
                    Cost = 5690,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_13);



                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 576,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 1998,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 1,
                });
                var card_14 = new Resource()
                {
                    Name = "NVIDIA GeForce GTX 295",
                    Parameters = parameters_14,
                    Cost = 6990,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_14);



                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Частота ядер, МГц",
                    Value = 1546,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Частота памяти, МГц",
                    Value = 1890,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Объем памяти, Гб",
                    Value = 8,
                });
                var card_15 = new Resource()
                {
                    Name = "AMD Radeon RX Vega 64",
                    Parameters = parameters_15,
                    Cost = 57370,
                    Type = "Видеокарта"
                };
                db.Resources.Add(card_15);
            }
        }


        public void HDDSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "HDD/SSD") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1000,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 150,
                });
                var hdd_1 = new Resource()
                {
                    Name = "WD Blue",
                    Parameters = parameters_1,
                    Cost = 2699,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1000,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 196,
                });
                var hdd_2 = new Resource()
                {
                    Name = "Toshiba P300",
                    Parameters = parameters_2,
                    Cost = 2699,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 60,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 300,
                });
                var hdd_3 = new Resource()
                {
                    Name = "Toshiba P300",
                    Parameters = parameters_3,
                    Cost = 1099,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1000,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 210,
                });
                var hdd_4 = new Resource()
                {
                    Name = "Seagate 7200 BarraCuda",
                    Parameters = parameters_4,
                    Cost = 2750,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 440,
                });
                var hdd_5 = new Resource()
                {
                    Name = "Apacer AS350",
                    Parameters = parameters_5,
                    Cost = 1299,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 350,
                });
                var hdd_6 = new Resource()
                {
                    Name = "Palit UVS",
                    Parameters = parameters_6,
                    Cost = 1299,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_6);


                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 520,
                });
                var hdd_7 = new Resource()
                {
                    Name = "A-Data SU650",
                    Parameters = parameters_7,
                    Cost = 1350,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_7);



                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 60,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 400,
                });
                var hdd_8 = new Resource()
                {
                    Name = "AFOX AFSN8T3BN60G",
                    Parameters = parameters_8,
                    Cost = 1350,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_8);


                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2000,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 180,
                });
                var hdd_9 = new Resource()
                {
                    Name = "Seagate 5900 IronWolf",
                    Parameters = parameters_9,
                    Cost = 4899,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_9);


                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2000,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 145,
                });
                var hdd_10 = new Resource()
                {
                    Name = "WD Purple",
                    Parameters = parameters_10,
                    Cost = 5299,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_10);


                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 350,
                });
                var hdd_11 = new Resource()
                {
                    Name = "GIGABYTE",
                    Parameters = parameters_11,
                    Cost = 1399,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_11);



                var parameters_12 = new List<Parameter>();
                parameters_12.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 550,
                });
                var hdd_12 = new Resource()
                {
                    Name = "SiliconPower Slim S55",
                    Parameters = parameters_12,
                    Cost = 1399,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_12);



                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 60,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 560,
                });
                var hdd_13 = new Resource()
                {
                    Name = "Leven JS300",
                    Parameters = parameters_13,
                    Cost = 1399,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_13);


                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 540,
                });
                var hdd_14 = new Resource()
                {
                    Name = "Crucial BX500",
                    Parameters = parameters_14,
                    Cost = 1450,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_14);


                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 120,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Скорость обмена, Мбайт/с",
                    Value = 500,
                });
                var hdd_15 = new Resource()
                {
                    Name = "Smartbuy Jolt",
                    Parameters = parameters_15,
                    Cost = 1450,
                    Type = "HDD/SSD"
                };
                db.Resources.Add(hdd_15);
            }
        }

        public void RAMSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "RAM") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2,
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 1600,
                });
                var ram_1 = new Resource()
                {
                    Name = "Patriot Signature",
                    Parameters = parameters_1,
                    Cost = 730,
                    Type = "RAM"
                };
                db.Resources.Add(ram_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2,
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 1600,
                });
                var ram_2 = new Resource()
                {
                    Name = "Foxline",
                    Parameters = parameters_2,
                    Cost = 750,
                    Type = "RAM"
                };
                db.Resources.Add(ram_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1,
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 800,
                });
                var ram_3 = new Resource()
                {
                    Name = "Kingston ValueRAM",
                    Parameters = parameters_3,
                    Cost = 910,
                    Type = "RAM"
                };
                db.Resources.Add(ram_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2,
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 1333,
                });
                var ram_4 = new Resource()
                {
                    Name = "Kingston ValueRAM [KVR13N9S6/2]",
                    Parameters = parameters_4,
                    Cost = 970,
                    Type = "RAM"
                };
                db.Resources.Add(ram_4);



                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 4,
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 2666,
                });
                var ram_5 = new Resource()
                {
                    Name = "Crucial [CT4G4RFS8266]",
                    Parameters = parameters_5,
                    Cost = 4499,
                    Type = "RAM"
                };
                db.Resources.Add(ram_5);



                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 8,
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 2400,
                });
                var ram_6 = new Resource()
                {
                    Name = "Kingston [KSM24RS8/8MAI]",
                    Parameters = parameters_6,
                    Cost = 5799,
                    Type = "RAM"
                };
                db.Resources.Add(ram_6);


                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1,
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 800,
                });
                var ram_7 = new Resource()
                {
                    Name = "JRam [JAL1G800D2]",
                    Parameters = parameters_7,
                    Cost = 999,
                    Type = "RAM"
                };
                db.Resources.Add(ram_7);



                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 1,
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 400,
                });
                var ram_8 = new Resource()
                {
                    Name = "QUMO [QUM1U-1G400T3]",
                    Parameters = parameters_8,
                    Cost = 999,
                    Type = "RAM"
                };
                db.Resources.Add(ram_8);


                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2,
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 800,
                });
                var ram_9 = new Resource()
                {
                    Name = "AMD Radeon R3 Value Series",
                    Parameters = parameters_9,
                    Cost = 1099,
                    Type = "RAM"
                };
                db.Resources.Add(ram_9);


                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 2,
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 1033,
                });
                var ram_10 = new Resource()
                {
                    Name = "Goodram [GR1333D364L9/2G]",
                    Parameters = parameters_10,
                    Cost = 1099,
                    Type = "RAM"
                };
                db.Resources.Add(ram_10);


                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 4,
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 1600,
                });
                var ram_11 = new Resource()
                {
                    Name = "Smartbuy [SBDR3-UD4GS-1600-11]",
                    Parameters = parameters_11,
                    Cost = 1350,
                    Type = "RAM"
                };
                db.Resources.Add(ram_11);


                var parameters_12 = new List<Parameter>();
                parameters_12.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 4,
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 2400,
                });
                var ram_12 = new Resource()
                {
                    Name = "Goodram [W-MEM24E4S84G]",
                    Parameters = parameters_12,
                    Cost = 3050,
                    Type = "RAM"
                };
                db.Resources.Add(ram_12);



                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 16,
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 2666,
                });
                var ram_13 = new Resource()
                {
                    Name = "Hynix [HMA82GR7AFR4N-VKT3]",
                    Parameters = parameters_13,
                    Cost = 10799,
                    Type = "RAM"
                };
                db.Resources.Add(ram_13);


                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 32,
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 2400,
                });
                var ram_14 = new Resource()
                {
                    Name = "Samsung [M393A4K40CB1-CRC]",
                    Parameters = parameters_14,
                    Cost = 26799,
                    Type = "RAM"
                };
                db.Resources.Add(ram_14);


                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Объем, Гб",
                    Value = 4,
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Частота, МГц",
                    Value = 3000,
                });
                var ram_15 = new Resource()
                {
                    Name = "A-Data XPG Gammix D10",
                    Parameters = parameters_15,
                    Cost = 2099,
                    Type = "RAM"
                };
                db.Resources.Add(ram_15);
            }
        }


        public void PrinterSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Принтер") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 20
                });
                var printer_1 = new Resource()
                {
                    Name = "Pantum P2200",
                    Parameters = parameters_1,
                    Cost = 4250,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 20
                });
                var printer_2 = new Resource()
                {
                    Name = "Samsung SL-M2020",
                    Parameters = parameters_2,
                    Cost = 5599,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_2);

                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 23
                });
                var printer_3 = new Resource()
                {
                    Name = "Ricoh SP 220Nw",
                    Parameters = parameters_3,
                    Cost = 5899,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 22
                });
                var printer_4 = new Resource()
                {
                    Name = "HP LaserJet Pro M104a",
                    Parameters = parameters_4,
                    Cost = 6499,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 26
                });
                var printer_5 = new Resource()
                {
                    Name = "Brother HL-L2300DR",
                    Parameters = parameters_5,
                    Cost = 7999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 26
                });
                var printer_6 = new Resource()
                {
                    Name = "Xerox Phaser 3052NI",
                    Parameters = parameters_6,
                    Cost = 9099,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_6);

                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 35
                });
                var printer_7 = new Resource()
                {
                    Name = "Kyocera ECOSYS P2335d",
                    Parameters = parameters_7,
                    Cost = 9499,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_7);


                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 33
                });
                var printer_8 = new Resource()
                {
                    Name = "Lexmark MS312dn",
                    Parameters = parameters_8,
                    Cost = 11299,
                    Type = "v"
                };
                db.Resources.Add(printer_8);



                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 28
                });
                var printer_9 = new Resource()
                {
                    Name = "Canon i-SENSYS LBP162dw",
                    Parameters = parameters_9,
                    Cost = 13299,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_9);



                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 36
                });
                var printer_10 = new Resource()
                {
                    Name = "Lexmark B2338dw",
                    Parameters = parameters_10,
                    Cost = 13999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_10);


                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 40
                });
                var printer_11 = new Resource()
                {
                    Name = "Kyocera ECOSYS P2040dn",
                    Parameters = parameters_11,
                    Cost = 14999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_11);


                var parameters_12 = new List<Parameter>();
                parameters_12.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 71
                });
                var printer_12 = new Resource()
                {
                    Name = "HP LaserJet Enterprise M609dn",
                    Parameters = parameters_12,
                    Cost = 32999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_12);


                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 51
                });
                var printer_13 = new Resource()
                {
                    Name = "Kyocera FS-9530DN",
                    Parameters = parameters_13,
                    Cost = 122999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_13);


                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 40
                });
                var printer_14 = new Resource()
                {
                    Name = "Xerox Phaser 3330",
                    Parameters = parameters_14,
                    Cost = 20799,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_14);


                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Скорость печати, стр/мин",
                    Value = 48
                });
                var printer_15 = new Resource()
                {
                    Name = "Samsung ML-5010ND",
                    Parameters = parameters_15,
                    Cost = 47999,
                    Type = "Принтер"
                };
                db.Resources.Add(printer_15);
            }
        }

        public void ScanerSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Сканер") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 8.5
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_1 = new Resource()
                {
                    Name = "Plustek OpticBook 3800",
                    Parameters = parameters_1,
                    Cost = 15299,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_1);

                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 6
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_2 = new Resource()
                {
                    Name = "Canon CanoScan LiDE 300",
                    Parameters = parameters_2,
                    Cost = 4499,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_2);

                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 5
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_3 = new Resource()
                {
                    Name = "Plustek OpticSlim 2610",
                    Parameters = parameters_3,
                    Cost = 4550,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_3);

                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 100
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_4 = new Resource()
                {
                    Name = "HP Digital Sender Flow 8500 fn2",
                    Parameters = parameters_4,
                    Cost = 211999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_4);

                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 80
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_5 = new Resource()
                {
                    Name = "Plustek SmartOffice PS456U",
                    Parameters = parameters_5,
                    Cost = 74999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_5);

                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 28.5
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_6 = new Resource()
                {
                    Name = "Plustek OpticPro A300 Plus",
                    Parameters = parameters_6,
                    Cost = 184999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_6);

                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 36
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_7 = new Resource()
                {
                    Name = "Plustek OpticPro A360 Plus",
                    Parameters = parameters_7,
                    Cost = 104999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_7);

                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_8 = new Resource()
                {
                    Name = "Mustek iDocScan D50",
                    Parameters = parameters_8,
                    Cost = 43999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_8);

                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 60
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_9 = new Resource()
                {
                    Name = "Fujitsu fi-7260",
                    Parameters = parameters_9,
                    Cost = 904999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_9);

                var parameters_10 = new List<Parameter>();
                parameters_10.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 25
                });
                parameters_10.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_10 = new Resource()
                {
                    Name = "Epson WorkForce DS-1630",
                    Parameters = parameters_10,
                    Cost = 16999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_10);


                var parameters_11 = new List<Parameter>();
                parameters_11.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 25
                });
                parameters_11.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_11 = new Resource()
                {
                    Name = "Mustek iDocScan D25",
                    Parameters = parameters_11,
                    Cost = 22999,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_11);

                var parameters_12 = new List<Parameter>();
                parameters_12.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 10
                });
                parameters_12.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_12 = new Resource()
                {
                    Name = "Avision FB5000",
                    Parameters = parameters_12,
                    Cost = 39299,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_12);

                var parameters_13 = new List<Parameter>();
                parameters_13.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 15
                });
                parameters_13.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_13 = new Resource()
                {
                    Name = "Plustek SmartOffice PL1530",
                    Parameters = parameters_13,
                    Cost = 25799,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_13);

                var parameters_14 = new List<Parameter>();
                parameters_14.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 7.5
                });
                parameters_14.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_14 = new Resource()
                {
                    Name = "Epson WorkForce DS-5500",
                    Parameters = parameters_14,
                    Cost = 43499,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_14);

                var parameters_15 = new List<Parameter>();
                parameters_15.Add(new Parameter()
                {
                    Key = "Скорость сканирования, стр/мин",
                    Value = 6.6
                });
                parameters_15.Add(new Parameter()
                {
                    Key = "Качество сканирования, %",
                    Value = 100
                });
                var scaner_15 = new Resource()
                {
                    Name = "Avision FB10",
                    Parameters = parameters_15,
                    Cost = 43499,
                    Type = "Сканер"
                };
                db.Resources.Add(scaner_15);
            }
        }

        public void CADSeed(ApplicationDbContext db)
        {
            if (db.Resources.FirstOrDefault(r => r.Type == "CAD") == null)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_1 = new Resource()
                {
                    Name = "PTC Creo",
                    Parameters = parameters_1,
                    Cost = 310000,
                    Type = "CAD"
                };
                db.Resources.Add(cad_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_2 = new Resource()
                {
                    Name = "SolidWorks",
                    Parameters = parameters_2,
                    Cost = 212200,
                    Type = "CAD"
                };
                db.Resources.Add(cad_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_3 = new Resource()
                {
                    Name = "Компас-3D",
                    Parameters = parameters_3,
                    Cost = 169000,
                    Type = "CAD"
                };
                db.Resources.Add(cad_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_4 = new Resource()
                {
                    Name = "AutoCAD",
                    Parameters = parameters_4,
                    Cost = 114622,
                    Type = "CAD"
                };
                db.Resources.Add(cad_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_5 = new Resource()
                {
                    Name = "TopoR",
                    Parameters = parameters_5,
                    Cost = 9000,
                    Type = "CAD"
                };
                db.Resources.Add(cad_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_6 = new Resource()
                {
                    Name = "Autodesk Inventor",
                    Parameters = parameters_6,
                    Cost = 51979,
                    Type = "CAD"
                };
                db.Resources.Add(cad_6);


                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_7 = new Resource()
                {
                    Name = "T-FLEX",
                    Parameters = parameters_7,
                    Cost = 129999,
                    Type = "CAD"
                };
                db.Resources.Add(cad_7);


                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var cad_8 = new Resource()
                {
                    Name = "CATIA",
                    Parameters = parameters_8,
                    Cost = 187000,
                    Type = "CAD"
                };
                db.Resources.Add(cad_8);
            }
        }


        public void HelpSoftwareSeed(ApplicationDbContext db)
        {
            if (db.Resources.FirstOrDefault(r => r.Type == "Вспом.ПО") == null)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_1 = new Resource()
                {
                    Name = "Microsoft Office 2003",
                    Parameters = parameters_1,
                    Cost = 5990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_1);


                var parameters_2 = new List<Parameter>();
                parameters_2.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_2.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_2 = new Resource()
                {
                    Name = "Microsoft Office 2007",
                    Parameters = parameters_2,
                    Cost = 6990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_2);


                var parameters_3 = new List<Parameter>();
                parameters_3.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_3.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_3 = new Resource()
                {
                    Name = "Microsoft Office 2010",
                    Parameters = parameters_3,
                    Cost = 10000,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_3);


                var parameters_4 = new List<Parameter>();
                parameters_4.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_4.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_4 = new Resource()
                {
                    Name = "Microsoft Visio 2003",
                    Parameters = parameters_4,
                    Cost = 750,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_4);


                var parameters_5 = new List<Parameter>();
                parameters_5.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_5.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_5 = new Resource()
                {
                    Name = "Microsoft Visio 2007",
                    Parameters = parameters_5,
                    Cost = 4990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_5);


                var parameters_6 = new List<Parameter>();
                parameters_6.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_6.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_6 = new Resource()
                {
                    Name = "Microsoft Visio 2010",
                    Parameters = parameters_6,
                    Cost = 6990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_6);


                var parameters_7 = new List<Parameter>();
                parameters_7.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_7.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_7 = new Resource()
                {
                    Name = "Microsoft Project 2003",
                    Parameters = parameters_7,
                    Cost = 9990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_7);


                var parameters_8 = new List<Parameter>();
                parameters_8.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_8.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_8 = new Resource()
                {
                    Name = "Microsoft Project 2010",
                    Parameters = parameters_8,
                    Cost = 15990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_8);


                var parameters_9 = new List<Parameter>();
                parameters_9.Add(new Parameter()
                {
                    Key = "Быстродействие",
                    Value = 50
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Сложность системы",
                    Value = 50
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Функциональность",
                    Value = 50
                });
                parameters_9.Add(new Parameter()
                {
                    Key = "Понятность интерфейса",
                    Value = 50
                });
                var soft_9 = new Resource()
                {
                    Name = "Microsoft Project 2016",
                    Parameters = parameters_9,
                    Cost = 54990,
                    Type = "Вспом.ПО"
                };
                db.Resources.Add(soft_9);
            }
        }

        public void StandardsSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Метод.обеспечение") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Доступность",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Полнота информации",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Понятность",
                    Value = 50
                });
                var method_1 = new Resource()
                {
                    Name = "ГОСТ-ы",
                    Parameters = parameters_1,
                    Cost = 0,
                    Type = "Метод.обеспечение"
                };
                db.Resources.Add(method_1);
            }
        }


        public void HumansSeed(ApplicationDbContext db)
        {
            if (db.Resources.Count(r => r.Type == "Человек") == 0)
            {
                var parameters_1 = new List<Parameter>();
                parameters_1.Add(new Parameter()
                {
                    Key = "Уровень знаний и компетенций",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Уровень навыков работы",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Степень мотивации",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Быстрообучаемость",
                    Value = 50
                });
                parameters_1.Add(new Parameter()
                {
                    Key = "Загруженность другими проектами",
                    Value = 50
                });
                var human_1 = new Resource()
                {
                    Name = "Проектировщик",
                    Parameters = parameters_1,
                    Cost = 50000,
                    Type = "Человек"
                };
                db.Resources.Add(human_1);
            }
        }
    }
}

