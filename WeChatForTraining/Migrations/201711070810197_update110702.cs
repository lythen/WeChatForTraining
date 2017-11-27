namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update110702 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sys_School", "delete_flag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sys_School", "delete_flag");
        }
    }
}
