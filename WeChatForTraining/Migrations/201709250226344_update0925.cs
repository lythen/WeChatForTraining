namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0925 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User_vs_Role");
            AddColumn("dbo.User_vs_Role", "uvr_user_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.User_vs_Role", new[] { "uvr_user_id", "uvr_role_id" });
            DropColumn("dbo.User_vs_Role", "uvr_uer_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_vs_Role", "uvr_uer_id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.User_vs_Role");
            DropColumn("dbo.User_vs_Role", "uvr_user_id");
            AddPrimaryKey("dbo.User_vs_Role", new[] { "uvr_uer_id", "uvr_role_id" });
        }
    }
}
