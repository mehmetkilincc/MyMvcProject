namespace MyMvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "Surname", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "Role", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Role", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "Surname");
            DropColumn("dbo.Admins", "Name");
        }
    }
}
