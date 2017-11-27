namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110802 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_vs_Subject", "uvs_role", c => c.Int(nullable: false));
            DropColumn("dbo.User_vs_Subject", "uvs_role_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_vs_Subject", "uvs_role_id", c => c.Int(nullable: false));
            DropColumn("dbo.User_vs_Subject", "uvs_role");
        }
    }
}
