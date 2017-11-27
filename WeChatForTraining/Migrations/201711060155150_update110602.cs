namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110602 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User_Info", "user_password2");
            DropColumn("dbo.User_Info", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User_Info", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.User_Info", "user_password2", c => c.String(maxLength: 32));
        }
    }
}
