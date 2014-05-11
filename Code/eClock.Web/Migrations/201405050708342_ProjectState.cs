namespace eClock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "State");
        }
    }
}
