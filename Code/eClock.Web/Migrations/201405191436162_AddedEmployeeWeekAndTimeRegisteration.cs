namespace eClock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeWeekAndTimeRegisteration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Week_StartDate = c.DateTime(nullable: false),
                        Week_EndDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.RegisteredHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monday = c.Double(nullable: false),
                        Tuesday = c.Double(nullable: false),
                        Wednesday = c.Double(nullable: false),
                        Thursday = c.Double(nullable: false),
                        Friday = c.Double(nullable: false),
                        Saturday = c.Double(nullable: false),
                        Sunday = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeWeekId = c.Int(nullable: false),
                        WorkItemId = c.Int(nullable: false),
                        RegisteredHoursId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeWeeks", t => t.EmployeeWeekId, cascadeDelete: true)
                .ForeignKey("dbo.RegisteredHours", t => t.RegisteredHoursId, cascadeDelete: true)
                .ForeignKey("dbo.WorkItems", t => t.WorkItemId, cascadeDelete: false)
                .Index(t => t.EmployeeWeekId)
                .Index(t => t.RegisteredHoursId)
                .Index(t => t.WorkItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeRegistrations", "WorkItemId", "dbo.WorkItems");
            DropForeignKey("dbo.TimeRegistrations", "RegisteredHoursId", "dbo.RegisteredHours");
            DropForeignKey("dbo.TimeRegistrations", "EmployeeWeekId", "dbo.EmployeeWeeks");
            DropForeignKey("dbo.EmployeeWeeks", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.TimeRegistrations", new[] { "WorkItemId" });
            DropIndex("dbo.TimeRegistrations", new[] { "RegisteredHoursId" });
            DropIndex("dbo.TimeRegistrations", new[] { "EmployeeWeekId" });
            DropIndex("dbo.EmployeeWeeks", new[] { "EmployeeId" });
            DropTable("dbo.RegisteredHours");
            DropTable("dbo.TimeRegistrations");
            DropTable("dbo.EmployeeWeeks");
        }
    }
}
