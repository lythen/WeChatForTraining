namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1108 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dic_Subject", "sub_introduce", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dic_Subject", "sub_introduce");
        }
    }
}
