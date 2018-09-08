using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Text;
using Lythen.Models;

namespace Lythen.DAL
{
    public class LythenContext :  DbContext
    {
        public LythenContext():base("ConnectionContext") { }
        public DbSet<User_Info> User_Infos { get; set; }
        public DbSet<Sys_Log> Sys_Logs { get; set; }
        public DbSet<Student_Info> Student_Infos { get; set; }
        public DbSet<Course_Info> Course_Infos { get; set; }
        public DbSet<Course_vs_Time> Course_vs_Times { get; set; }
        public DbSet<Dic_Course_State> Dic_Course_States { get; set; }
        public DbSet<Dic_Level> Dic_Levels { get; set; }
        public DbSet<Dic_Relation> Dic_Relations { get; set; }
        public DbSet<Dic_Roll_Call> Dic_Roll_Calls { get; set; }
        public DbSet<Dic_Subject> Dic_Subjects { get; set; }
        public DbSet<Student_vs_Course> Student_vs_Courses { get; set; }
        public DbSet<Student_vs_CTimes> Student_vs_CTimess { get; set; }
        public DbSet<Student_vs_Level> Student_vs_Levels { get; set; }
        public DbSet<Sys_Roles> Sys_Roles { get; set; }
        public DbSet<User_vs_Role> User_vs_Roles { get; set; }
        public DbSet<User_vs_Student> User_vs_Students { get; set; }
        public DbSet<User_vs_Subject> User_vs_Subjects { get; set; }
        public DbSet<User_vs_Wechat> User_vs_Wechats { get; set; }
        public DbSet<Dic_School> Dic_Schools { get; set; }
        public DbSet<Dic_Grade> Dic_Grades { get; set; }
        public DbSet<Dic_Course_Type> Dic_Course_Types { get; set; }
        public DbSet<Dic_CardType> Dic_CardTypes { get; set; }
        public DbSet<Sys_School> Sys_Schools { get; set; }
        public DbSet<Course_Season> Course_Seasons { get; set; }
        public DbSet<Course_SuspendTime> Course_SuspendTimes { get; set; }
        public DbSet<Sys_ClassRoom> Sys_ClassRooms { get; set; }
        public DbSet<Sys_Info> Sys_Info { get; set; }
        public DbSet<Role_vs_Controller> Role_vs_Controllers { get; set; }
        public DbSet<Sys_Controller> Sys_Controllers { get; set; }
        public DbSet<Sys_Authority> Sys_Authority { get; set; }
        public DbSet<Role_vs_Authority> Role_vs_Authority { get; set; }
        public DbSet<Sys_SiteInfo> Sys_SiteInfo { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //修改
        //    //modelBuilder.Entity<User_Info>()
        //    //    .Property(u => u.user_id)
        //    //    .HasColumnName("user_id");
        //}
        //重写SaveChanges方法
        public override int SaveChanges()
        {
            StringBuilder sql = new StringBuilder();
            //记录实体操作日志
            this.Database.Log = (a) =>
            {
                sql.Append(a);
            };
            try
            {
                using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["sqlLog"], true))
                {
                    sw.WriteLineAsync(sql.ToString());
                }
            }
            catch { }
            //这里的sql就是操作日志了,想记哪就记哪吧.这里我就不实现了.
            return base.SaveChanges();
        }
    }
}