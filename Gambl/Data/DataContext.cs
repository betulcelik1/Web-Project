using Microsoft.EntityFrameworkCore;
using Gambl.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gambl.Data
{
    
    public class  DataContext :DbContext{
        public DataContext(DbContextOptions<DataContext>options):base(options)
    {
        
    }
        public DbSet<CourseBuy> CourseBuys=>Set<CourseBuy>();
        public DbSet<UserInfo> UserInfos=>Set<UserInfo>();
        public DbSet<CourseInfo> CourseInfos=>Set<CourseInfo>();
        public DbSet<InstructorInfo> InstructorInfos=>Set<InstructorInfo>();
        public DbSet<LessonInfo> LessonInfos=>Set<LessonInfo>();
        public DbSet<ContentInfo> ContentInfos=>Set<ContentInfo>();
        public DbSet<InstructorCoursesViewModel> InstructorCourses=>Set<InstructorCoursesViewModel>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseInfo>().HasMany(t => t.Lessons).WithOne().HasForeignKey(l => l.CourseInfoCourseId);
            modelBuilder.Entity<LessonInfo>().HasMany(l => l.content).WithOne().HasForeignKey(t => t.LessonInfoLessonId);
            base.OnModelCreating(modelBuilder);
        }







    }

    
}