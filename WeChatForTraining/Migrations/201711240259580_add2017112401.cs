namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2017112401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role_vs_Controller",
                c => new
                    {
                        rvc_role_id = c.Int(nullable: false),
                        rvc_controller = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.rvc_role_id, t.rvc_controller });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role_vs_Controller");
        }
    }
}
