namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMig09222 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Student_vs_CTimes");
            AlterColumn("dbo.Student_vs_CTimes", "svct_stu_id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Student_vs_CTimes", new[] { "svct_stu_id", "svct_cvt_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Student_vs_CTimes");
            AlterColumn("dbo.Student_vs_CTimes", "svct_stu_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Student_vs_CTimes", new[] { "svct_stu_id", "svct_cvt_id" });
        }
    }
}
