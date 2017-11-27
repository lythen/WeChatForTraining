namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course_vs_Time", "cvt_group", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course_vs_Time", "cvt_group");
        }
    }
}
