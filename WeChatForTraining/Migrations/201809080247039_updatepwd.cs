namespace Lythen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepwd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course_Info",
                c => new
                    {
                        course_id = c.Int(nullable: false, identity: true),
                        course_name = c.String(nullable: false, maxLength: 50),
                        course_introduce = c.String(),
                        course_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        course_max_num = c.Int(nullable: false),
                        c_sub_id = c.Int(nullable: false),
                        c_type_id = c.Int(nullable: false),
                        c_teacher_id = c.Int(nullable: false),
                        c_assistant_id = c.Int(nullable: false),
                        c_room = c.Int(nullable: false),
                        c_time_info = c.String(maxLength: 2000),
                        c_cs_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.course_id);
            
            CreateTable(
                "dbo.Course_Season",
                c => new
                    {
                        c_season_id = c.Int(nullable: false, identity: true),
                        c_season_name = c.String(nullable: false, maxLength: 30),
                        c_is_used = c.Boolean(nullable: false),
                        c_add_time = c.DateTime(),
                        c_add_user = c.Int(),
                    })
                .PrimaryKey(t => t.c_season_id);
            
            CreateTable(
                "dbo.Course_SuspendTime",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cst_course_id = c.Int(nullable: false),
                        cst_suspend_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Course_vs_Time",
                c => new
                    {
                        cvt_id = c.Int(nullable: false, identity: true),
                        cvt_time = c.DateTime(nullable: false),
                        cvt_dayofweek = c.Int(),
                        cvt_duration = c.Int(nullable: false),
                        cvt_course_id = c.Int(nullable: false),
                        cvt_info = c.String(),
                        cvt_state = c.Int(nullable: false),
                        cvt_is_extra = c.Boolean(nullable: false),
                        cvt_room_id = c.Int(),
                        cvt_group = c.Int(),
                    })
                .PrimaryKey(t => t.cvt_id);
            
            CreateTable(
                "dbo.Dic_CardType",
                c => new
                    {
                        ctype_id = c.Int(nullable: false, identity: true),
                        ctype_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ctype_id);
            
            CreateTable(
                "dbo.Dic_Course_State",
                c => new
                    {
                        cstate_id = c.Int(nullable: false, identity: true),
                        cstate_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.cstate_id);
            
            CreateTable(
                "dbo.Dic_Course_Type",
                c => new
                    {
                        ct_id = c.Int(nullable: false, identity: true),
                        ct_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ct_id);
            
            CreateTable(
                "dbo.Dic_Grade",
                c => new
                    {
                        grade_id = c.Int(nullable: false, identity: true),
                        grade_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.grade_id);
            
            CreateTable(
                "dbo.Dic_Level",
                c => new
                    {
                        level_id = c.Int(nullable: false, identity: true),
                        level_sub_id = c.Int(nullable: false),
                        level_name = c.String(nullable: false, maxLength: 50),
                        level_info = c.String(),
                    })
                .PrimaryKey(t => t.level_id);
            
            CreateTable(
                "dbo.Dic_Relation",
                c => new
                    {
                        relstion_id = c.Int(nullable: false, identity: true),
                        relation_name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.relstion_id);
            
            CreateTable(
                "dbo.Dic_Roll_Call",
                c => new
                    {
                        rc_id = c.Int(nullable: false, identity: true),
                        rc_name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.rc_id);
            
            CreateTable(
                "dbo.Dic_School",
                c => new
                    {
                        school_id = c.Int(nullable: false, identity: true),
                        school_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.school_id);
            
            CreateTable(
                "dbo.Dic_Subject",
                c => new
                    {
                        sub_id = c.Int(nullable: false, identity: true),
                        sub_name = c.String(nullable: false, maxLength: 30),
                        delete_flag = c.Int(nullable: false),
                        sub_introduce = c.String(),
                    })
                .PrimaryKey(t => t.sub_id);
            
            CreateTable(
                "dbo.Role_vs_Authority",
                c => new
                    {
                        rva_role_id = c.Int(nullable: false),
                        rva_auth_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.rva_role_id, t.rva_auth_id });
            
            CreateTable(
                "dbo.Role_vs_Controller",
                c => new
                    {
                        rvc_role_id = c.Int(nullable: false),
                        rvc_controller = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.rvc_role_id, t.rvc_controller });
            
            CreateTable(
                "dbo.Student_Info",
                c => new
                    {
                        stu_id = c.String(nullable: false, maxLength: 10),
                        stu_name = c.String(nullable: false, maxLength: 50),
                        stu_password = c.String(maxLength: 36),
                        stu_card_type = c.Int(nullable: false),
                        stu_idCard = c.String(maxLength: 18),
                        stu_sex = c.String(nullable: false, maxLength: 2),
                        stu_birthday = c.DateTime(nullable: false),
                        stu_photo_path = c.String(),
                        stu_phone = c.String(),
                        stu_email = c.String(),
                        stu_school_id = c.Int(nullable: false),
                        stu_grade_id = c.Int(nullable: false),
                        stu_home_address = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.stu_id);
            
            CreateTable(
                "dbo.Student_vs_Course",
                c => new
                    {
                        svc_stu_id = c.String(nullable: false, maxLength: 128),
                        svc_course_id = c.Int(nullable: false),
                        svc_add_time = c.DateTime(nullable: false),
                        svc_add_user = c.Int(nullable: false),
                        svc_update_time = c.DateTime(),
                        svc_update_user = c.Int(nullable: false),
                        svc_pay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        svc_info = c.String(),
                        svc_is_end = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.svc_stu_id, t.svc_course_id });
            
            CreateTable(
                "dbo.Student_vs_CTimes",
                c => new
                    {
                        svct_stu_id = c.String(nullable: false, maxLength: 128),
                        svct_cvt_id = c.Int(nullable: false),
                        svct_roll_call = c.Int(nullable: false),
                        svct_roll_call_info = c.String(),
                    })
                .PrimaryKey(t => new { t.svct_stu_id, t.svct_cvt_id });
            
            CreateTable(
                "dbo.Student_vs_Level",
                c => new
                    {
                        svl_stu_id = c.Int(nullable: false),
                        svl_level_id = c.Int(nullable: false),
                        svl_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.svl_stu_id, t.svl_level_id });
            
            CreateTable(
                "dbo.Sys_Authority",
                c => new
                    {
                        auth_id = c.Int(nullable: false, identity: true),
                        auth_name = c.String(nullable: false, maxLength: 20),
                        auth_is_Controller = c.Boolean(nullable: false),
                        auth_map_Controller = c.Int(nullable: false),
                        auth_info = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.auth_id);
            
            CreateTable(
                "dbo.Sys_ClassRoom",
                c => new
                    {
                        room_id = c.Int(nullable: false, identity: true),
                        room_name = c.String(nullable: false, maxLength: 50),
                        room_school_id = c.Int(nullable: false),
                        room_sear_num = c.Int(nullable: false),
                        room_info = c.String(),
                    })
                .PrimaryKey(t => t.room_id);
            
            CreateTable(
                "dbo.Sys_Controller",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        controller_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.Sys_Roles",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        role_name = c.String(nullable: false, maxLength: 50),
                        role_info = c.String(),
                    })
                .PrimaryKey(t => t.role_id);
            
            CreateTable(
                "dbo.Sys_School",
                c => new
                    {
                        sys_school_id = c.Int(nullable: false, identity: true),
                        sys_school_name = c.String(nullable: false, maxLength: 50),
                        sys_school_phone = c.String(maxLength: 20),
                        sys_school_address = c.String(maxLength: 500),
                        sys_school_info = c.String(),
                        delete_flag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.sys_school_id);
            
            CreateTable(
                "dbo.User_Info",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(nullable: false, maxLength: 50),
                        user_photo_path = c.String(maxLength: 100),
                        user_phone = c.String(maxLength: 20),
                        user_info = c.String(),
                        user_email = c.String(maxLength: 100),
                        user_password = c.String(maxLength: 32),
                        user_Occupation = c.String(maxLength: 100),
                        user_home_address = c.String(maxLength: 500),
                        user_work_unit = c.String(maxLength: 150),
                        user_add_time = c.DateTime(nullable: false),
                        user_add_user = c.Int(nullable: false),
                        user_update_time = c.DateTime(),
                        user_update_user = c.Int(nullable: false),
                        user_login_times = c.Int(nullable: false),
                        user_state = c.Int(nullable: false),
                        user_is_teacher = c.Boolean(nullable: false),
                        user_salt = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.User_vs_Role",
                c => new
                    {
                        uvr_user_id = c.Int(nullable: false),
                        uvr_role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.uvr_user_id);
            
            CreateTable(
                "dbo.User_vs_Student",
                c => new
                    {
                        uvs_stu_id = c.String(nullable: false, maxLength: 10),
                        uvs_user_id = c.Int(nullable: false),
                        uvs_relation_id = c.Int(nullable: false),
                        uvs_state = c.Int(nullable: false),
                        uvs_is_get_msg = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.uvs_stu_id, t.uvs_user_id });
            
            CreateTable(
                "dbo.User_vs_Subject",
                c => new
                    {
                        uvs_user_id = c.Int(nullable: false),
                        uvs_sub_id = c.Int(nullable: false),
                        uvs_role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.uvs_user_id, t.uvs_sub_id });
            
            CreateTable(
                "dbo.User_vs_Wechat",
                c => new
                    {
                        uvw_uer_id = c.Int(nullable: false),
                        uvw_open_id = c.String(nullable: false, maxLength: 50),
                        uvw_wx_id = c.String(maxLength: 30),
                        uvw_wx_name = c.String(maxLength: 50),
                        uvw_wx_token = c.String(maxLength: 64),
                        uvw_state = c.Int(nullable: false),
                        uvw_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.uvw_uer_id, t.uvw_open_id });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User_vs_Wechat");
            DropTable("dbo.User_vs_Subject");
            DropTable("dbo.User_vs_Student");
            DropTable("dbo.User_vs_Role");
            DropTable("dbo.User_Info");
            DropTable("dbo.Sys_School");
            DropTable("dbo.Sys_Roles");
            DropTable("dbo.Sys_Log");
            DropTable("dbo.Sys_Info");
            DropTable("dbo.Sys_Controller");
            DropTable("dbo.Sys_ClassRoom");
            DropTable("dbo.Sys_Authority");
            DropTable("dbo.Student_vs_Level");
            DropTable("dbo.Student_vs_CTimes");
            DropTable("dbo.Student_vs_Course");
            DropTable("dbo.Student_Info");
            DropTable("dbo.Role_vs_Controller");
            DropTable("dbo.Role_vs_Authority");
            DropTable("dbo.Dic_Subject");
            DropTable("dbo.Dic_School");
            DropTable("dbo.Dic_Roll_Call");
            DropTable("dbo.Dic_Relation");
            DropTable("dbo.Dic_Level");
            DropTable("dbo.Dic_Grade");
            DropTable("dbo.Dic_Course_Type");
            DropTable("dbo.Dic_Course_State");
            DropTable("dbo.Dic_CardType");
            DropTable("dbo.Course_vs_Time");
            DropTable("dbo.Course_SuspendTime");
            DropTable("dbo.Course_Season");
            DropTable("dbo.Course_Info");
        }
    }
}
