namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1107021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dic_Subject", "delete_flag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dic_Subject", "delete_flag");
        }
    }
}
