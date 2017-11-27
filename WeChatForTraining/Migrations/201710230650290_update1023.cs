namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1023 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sys_Roles");
            AddColumn("dbo.Student_Info", "stu_password", c => c.String(maxLength: 36));
            AlterColumn("dbo.Sys_Roles", "role_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sys_Roles", "role_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Sys_Roles");
            AlterColumn("dbo.Sys_Roles", "role_id", c => c.Int(nullable: false));
            DropColumn("dbo.Student_Info", "stu_password");
            AddPrimaryKey("dbo.Sys_Roles", "role_id");
        }
    }
}
