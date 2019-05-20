namespace GidraSIM.NewDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Double(nullable: false),
                        Process_Id = c.Int(),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Processes", t => t.Process_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Process_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Process_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Processes", t => t.Process_Id)
                .Index(t => t.Process_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "Process_Id", "dbo.Processes");
            DropForeignKey("dbo.Properties", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Properties", "Process_Id", "dbo.Processes");
            DropIndex("dbo.Resources", new[] { "Process_Id" });
            DropIndex("dbo.Properties", new[] { "Resource_Id" });
            DropIndex("dbo.Properties", new[] { "Process_Id" });
            DropTable("dbo.Resources");
            DropTable("dbo.Properties");
            DropTable("dbo.Processes");
        }
    }
}
