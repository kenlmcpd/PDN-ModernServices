namespace ModernDataServices.App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Person_PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Person_PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaCode = c.String(),
                        Number = c.String(),
                        Extension = c.String(),
                        Person_PersonId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.LogTables",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ApplicationName = c.String(),
                        Time_Stamp = c.DateTime(nullable: false),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                        Verbose = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Emails", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Addresses", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Phones", new[] { "Person_PersonId" });
            DropIndex("dbo.Emails", new[] { "Person_PersonId" });
            DropIndex("dbo.Addresses", new[] { "Person_PersonId" });
            DropTable("dbo.LogTables");
            DropTable("dbo.Phones");
            DropTable("dbo.Emails");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
