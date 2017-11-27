namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2017112402 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_Controller",
                c => new
                    {
                        controller_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.controller_name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sys_Controller");
        }
    }
}
