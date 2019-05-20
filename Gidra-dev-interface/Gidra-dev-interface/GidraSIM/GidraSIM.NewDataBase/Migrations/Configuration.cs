namespace GidraSIM.NewDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GidraSIM.NewDataBase.GidraDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GidraSIM.NewDataBase.GidraDbContext context)
        {
            context.Processes.AddOrUpdate(x => x.Id,
                new Process() { Id = 1, Name = "Трассировка" });

            context.Resources.AddOrUpdate(x => x.Id,
                new Resource() { Id = 1, Name = "Компьютер" });

            context.Properties.AddOrUpdate(x => x.Id,
                new Property() { Id = 1, Name = "Имя свойства", Value = 5.5 });
        }
    }
}
