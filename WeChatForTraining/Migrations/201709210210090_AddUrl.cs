namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student_Info", "stu_card_type", c => c.String(maxLength: 50));
            AddColumn("dbo.Student_Info", "stu_idCard", c => c.String(maxLength: 18));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student_Info", "stu_idCard");
            DropColumn("dbo.Student_Info", "stu_card_type");
        }
    }
}
