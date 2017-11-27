namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10122 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course_Info", "c_room", c => c.Int());
            AddColumn("dbo.Course_vs_Time", "cvt_room_id", c => c.Int());
            DropColumn("dbo.Course_Info", "c_sys_school");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course_Info", "c_sys_school", c => c.Int());
            DropColumn("dbo.Course_vs_Time", "cvt_room_id");
            DropColumn("dbo.Course_Info", "c_room");
        }
    }
}
