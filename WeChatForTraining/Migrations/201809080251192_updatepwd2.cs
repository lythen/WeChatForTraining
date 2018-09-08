namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepwd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User_Info", "user_password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User_Info", "user_password", c => c.String(maxLength: 32));
        }
    }
}
