namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110803 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User_vs_Role");
            AddPrimaryKey("dbo.User_vs_Role", "uvr_user_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.User_vs_Role");
            AddPrimaryKey("dbo.User_vs_Role", new[] { "uvr_user_id", "uvr_role_id" });
        }
    }
}
