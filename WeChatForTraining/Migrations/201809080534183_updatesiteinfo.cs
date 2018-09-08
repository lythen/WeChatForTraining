namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesiteinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_SiteInfo",
                c => new
                    {
                        site_name = c.String(nullable: false, maxLength: 100),
                        site_company = c.String(maxLength: 100),
                        site_introduce = c.String(maxLength: 2000),
                        site_company_address = c.String(maxLength: 200),
                        site_company_phone = c.String(maxLength: 20),
                        site_company_email = c.String(maxLength: 100),
                        site_manager_name = c.String(maxLength: 50),
                        site_manager_phone = c.String(maxLength: 20),
                        site_manager_email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.site_name);
            
            AddColumn("dbo.User_Info", "user_gender", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Info", "user_gender");
            DropTable("dbo.Sys_SiteInfo");
        }
    }
}
