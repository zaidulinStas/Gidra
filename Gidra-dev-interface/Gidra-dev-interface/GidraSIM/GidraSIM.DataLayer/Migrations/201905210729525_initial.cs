namespace GidraSIM.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ProgressFunction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Key = c.String(),
                        Value = c.Double(nullable: false),
                        Procedure_Id = c.String(maxLength: 128),
                        Resource_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Procedure_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameters", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.Parameters", "Procedure_Id", "dbo.Procedures");
            DropIndex("dbo.Parameters", new[] { "Resource_Id" });
            DropIndex("dbo.Parameters", new[] { "Procedure_Id" });
            DropTable("dbo.Resources");
            DropTable("dbo.Parameters");
            DropTable("dbo.Procedures");
        }
    }
}
