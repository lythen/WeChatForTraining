namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1107 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_Info",
                c => new
                    {
                        company_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(maxLength: 200),
                        company_introduce = c.String(),
                        company_address = c.String(maxLength: 500),
                        company_phone = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.company_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sys_Info");
        }
    }
}
