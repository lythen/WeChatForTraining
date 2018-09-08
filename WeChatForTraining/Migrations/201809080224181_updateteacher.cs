namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateteacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User_Info", "user_is_teacher", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Info", "user_is_teacher");
        }
    }
}
