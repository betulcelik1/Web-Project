using Microsoft.EntityFrameworkCore;
using Gambl.Models;

namespace Gambl.Data
{
    
    public class  DataContext :DbContext{
        public DataContext(DbContextOptions<DataContext>options):base(options)
    {
        
    }
        public DbSet<CourseBuy> CourseBuys=>Set<CourseBuy>();
        public DbSet<UserInfo> UserInfos=>Set<UserInfo>();
        public DbSet<CourseInfo> CourseInfos=>Set<CourseInfo>();
        public DbSet<LessonInfo> LessonInfos=>Set<LessonInfo>();
        public DbSet<ContentInfo> ContentInfos=>Set<ContentInfo>();
        public DbSet<InstructorInfo> InstructorInfos=>Set<InstructorInfo>();
    }

    
}