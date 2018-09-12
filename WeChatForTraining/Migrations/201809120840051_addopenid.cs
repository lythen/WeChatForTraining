namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addopenid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_vs_OpenId",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        open_id = c.String(maxLength: 250),
                        bind_date = c.DateTime(nullable: false),
                        bind_method = c.String(maxLength: 250),
                        bind_user = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.user_id);
            
            AddColumn("dbo.User_Info", "user_bindCode", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Info", "user_bindCode");
            DropTable("dbo.User_vs_OpenId");
        }
    }
}
