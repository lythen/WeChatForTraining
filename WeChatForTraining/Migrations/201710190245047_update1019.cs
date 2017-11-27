namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course_Info", "c_room", c => c.Int(nullable: false));
            AlterColumn("dbo.Course_Info", "c_cs_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course_Info", "c_cs_id", c => c.Int());
            AlterColumn("dbo.Course_Info", "c_room", c => c.Int());
        }
    }
}
