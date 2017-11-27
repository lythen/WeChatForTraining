namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl0921 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student_Info", "stu_card_type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student_Info", "stu_card_type", c => c.String(maxLength: 50));
        }
    }
}
