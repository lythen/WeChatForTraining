namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10132 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course_Info", "c_time_info", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course_Info", "c_time_info", c => c.String(maxLength: 20));
        }
    }
}
