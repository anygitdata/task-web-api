namespace TaskWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabinets",
                c => new
                    {
                        CabinetId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CabinetId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100, unicode: false),
                        CabinetId = c.Int(nullable: false),
                        SpecializationId = c.Int(nullable: false),
                        SectorId = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Cabinets", t => t.CabinetId, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorId)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.CabinetId)
                .Index(t => t.SpecializationId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        SectorId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        Sername = c.String(nullable: false, maxLength: 50, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 100, unicode: false),
                        DateBirth = c.DateTime(nullable: false),
                        Pol = c.Boolean(nullable: false),
                        SectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SpecializationId)
                .Index(t => t.Title, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Patients", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Doctors", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Doctors", "CabinetId", "dbo.Cabinets");
            DropIndex("dbo.Specializations", new[] { "Title" });
            DropIndex("dbo.Patients", new[] { "SectorId" });
            DropIndex("dbo.Doctors", new[] { "SectorId" });
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropIndex("dbo.Doctors", new[] { "CabinetId" });
            DropTable("dbo.Specializations");
            DropTable("dbo.Patients");
            DropTable("dbo.Sectors");
            DropTable("dbo.Doctors");
            DropTable("dbo.Cabinets");
        }
    }
}
