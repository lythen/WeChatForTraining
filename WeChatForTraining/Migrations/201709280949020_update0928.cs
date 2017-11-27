namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0928 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course_Season",
                c => new
                    {
                        c_season_id = c.Int(nullable: false, identity: true),
                        c_season_name = c.String(nullable: false, maxLength: 30),
                        c_is_used = c.Boolean(nullable: false),
                        c_add_time = c.DateTime(),
                        c_add_user = c.Int(),
                    })
                .PrimaryKey(t => t.c_season_id);
            
            AddColumn("dbo.Course_Info", "c_time_info", c => c.String(maxLength: 20));
            AddColumn("dbo.Course_Info", "c_cs_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course_Info", "c_cs_id");
            DropColumn("dbo.Course_Info", "c_time_info");
            DropTable("dbo.Course_Season");
        }
    }
}
