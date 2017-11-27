namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1106 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Info", "user_password2", c => c.String(maxLength: 32));
            AddColumn("dbo.User_Info", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Info", "Discriminator");
            DropColumn("dbo.User_Info", "user_password2");
        }
    }
}
