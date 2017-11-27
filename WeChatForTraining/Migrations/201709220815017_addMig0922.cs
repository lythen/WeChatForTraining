namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMig0922 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Student_Info");
            AlterColumn("dbo.Student_Info", "stu_id", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.Student_Info", "stu_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Student_Info");
            AlterColumn("dbo.Student_Info", "stu_id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Student_Info", "stu_id");
        }
    }
}
