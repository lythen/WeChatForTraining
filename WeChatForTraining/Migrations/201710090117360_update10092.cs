namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10092 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course_SuspendTime",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cst_course_id = c.Int(nullable: false),
                        cst_suspend_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Course_SuspendTime");
        }
    }
}
