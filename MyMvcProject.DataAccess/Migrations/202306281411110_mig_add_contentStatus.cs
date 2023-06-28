namespace MyMvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_contentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "Status");
        }
    }
}
