namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1208 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sys_Controller");
            AddColumn("dbo.Sys_Controller", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sys_Controller", "controller_name", c => c.String());
            AddPrimaryKey("dbo.Sys_Controller", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Sys_Controller");
            AlterColumn("dbo.Sys_Controller", "controller_name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Sys_Controller", "id");
            AddPrimaryKey("dbo.Sys_Controller", "controller_name");
        }
    }
}
