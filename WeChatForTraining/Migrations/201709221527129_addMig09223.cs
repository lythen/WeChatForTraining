namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMig09223 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_School",
                c => new
                    {
                        sys_school_id = c.Int(nullable: false, identity: true),
                        sys_school_name = c.String(nullable: false, maxLength: 50),
                        sys_school_phone = c.String(maxLength: 20),
                        sys_school_address = c.String(maxLength: 500),
                        sys_school_info = c.String(),
                    })
                .PrimaryKey(t => t.sys_school_id);
            
            AddColumn("dbo.Course_Info", "c_sys_school", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course_Info", "c_sys_school");
            DropTable("dbo.Sys_School");
        }
    }
}
