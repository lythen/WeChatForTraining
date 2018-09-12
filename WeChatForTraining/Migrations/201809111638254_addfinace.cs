namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfinace : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dic_Reimbursement_Content",
                c => new
                    {
                        content_id = c.Int(nullable: false, identity: true),
                        content_title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.content_id);
            
            CreateTable(
                "dbo.Dic_Respond_State",
                c => new
                    {
                        drs_state_id = c.Int(nullable: false),
                        drs_state_name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.drs_state_id);
            
            CreateTable(
                "dbo.Process_Respond",
                c => new
                    {
                        pr_id = c.Int(nullable: false, identity: true),
                        pr_reimbursement_code = c.String(maxLength: 20),
                        pr_user_id = c.Int(nullable: false),
                        pr_number = c.Int(nullable: false),
                        pr_time = c.DateTime(),
                        pr_content = c.String(maxLength: 2000),
                        pr_state = c.Int(nullable: false),
                        next = c.Int(),
                    })
                .PrimaryKey(t => t.pr_id);
            
            CreateTable(
                "dbo.Reimbursements",
                c => new
                    {
                        reimbursement_code = c.String(nullable: false, maxLength: 9),
                        r_add_user_id = c.Int(nullable: false),
                        r_add_date = c.DateTime(nullable: false),
                        r_bill_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        r_bill_state = c.Int(nullable: false),
                        reimbursement_info = c.String(),
                        r_funds_id = c.Int(nullable: false),
                        r_fact_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        c_has_log = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.reimbursement_code);
            
            CreateTable(
                "dbo.Reimbursement_Attachment",
                c => new
                    {
                        attachment_id = c.Int(nullable: false, identity: true),
                        atta_reimbursement_code = c.String(maxLength: 9),
                        atta_detail_id = c.Int(nullable: false),
                        attachment_path = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.attachment_id);
            
            CreateTable(
                "dbo.Reimbursement_Content",
                c => new
                    {
                        content_id = c.Int(nullable: false, identity: true),
                        c_reimbursement_code = c.String(maxLength: 9),
                        c_funds_id = c.Int(nullable: false),
                        c_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        c_dic_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.content_id);
            
            CreateTable(
                "dbo.Reimbursement_Detail",
                c => new
                    {
                        detail_id = c.Int(nullable: false, identity: true),
                        detail_content_id = c.Int(nullable: false),
                        detail_info = c.String(maxLength: 200),
                        detail_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        detail_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.detail_id);
            
            CreateTable(
                "dbo.Sys_Logs",
                c => new
                    {
                        log_id = c.Int(nullable: false, identity: true),
                        log_user_id = c.Int(nullable: false),
                        log_target = c.String(maxLength: 100),
                        log_content = c.String(maxLength: 2000),
                        log_type = c.Int(nullable: false),
                        log_time = c.DateTime(nullable: false),
                        log_ip = c.String(maxLength: 150),
                        log_device = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.log_id);
            
            AddColumn("dbo.User_Info", "real_name", c => c.String(maxLength: 100));
            AlterColumn("dbo.User_Info", "user_info", c => c.String(maxLength: 100));
            DropTable("dbo.Sys_Log");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sys_Log",
                c => new
                    {
                        log_user_id = c.Int(nullable: false, identity: true),
                        log_user_ip = c.String(maxLength: 128),
                        log_time = c.DateTime(nullable: false),
                        log_device = c.String(maxLength: 200),
                        log_info = c.String(),
                    })
                .PrimaryKey(t => t.log_user_id);
            
            AlterColumn("dbo.User_Info", "user_info", c => c.String());
            DropColumn("dbo.User_Info", "real_name");
            DropTable("dbo.Sys_Logs");
            DropTable("dbo.Reimbursement_Detail");
            DropTable("dbo.Reimbursement_Content");
            DropTable("dbo.Reimbursement_Attachment");
            DropTable("dbo.Reimbursements");
            DropTable("dbo.Process_Respond");
            DropTable("dbo.Dic_Respond_State");
            DropTable("dbo.Dic_Reimbursement_Content");
        }
    }
}
