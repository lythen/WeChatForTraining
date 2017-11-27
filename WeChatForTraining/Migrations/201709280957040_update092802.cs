namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update092802 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student_vs_Course", "svc_is_end", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student_vs_Course", "svc_is_end");
        }
    }
}
