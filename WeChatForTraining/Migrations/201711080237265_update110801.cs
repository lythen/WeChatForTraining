namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110801 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Info", "user_state", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Info", "user_state");
        }
    }
}
