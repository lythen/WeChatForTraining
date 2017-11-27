namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1012 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_ClassRoom",
                c => new
                    {
                        room_id = c.Int(nullable: false, identity: true),
                        room_name = c.String(nullable: false, maxLength: 50),
                        room_school_id = c.Int(nullable: false),
                        room_sear_num = c.Int(nullable: false),
                        room_info = c.String(),
                    })
                .PrimaryKey(t => t.room_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sys_ClassRoom");
        }
    }
}
