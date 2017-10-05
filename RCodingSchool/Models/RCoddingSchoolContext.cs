using Microsoft.AspNet.Identity.EntityFramework;
using RCodingSchool.Session;
using System.Data.Entity;

namespace RCodingSchool.Models
{
	public class RCodingSchoolContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Group> Groups { get; set; }
//		public DbSet<Message> Messages { get; set; }
//		public DbSet<MessageGroup> MessagesGroups { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherGroup>()
                .HasKey(x => new { x.GroupId, x.TeacherId });

            modelBuilder.Entity<GroupSubject>()
                .HasKey(x => new { x.GroupId, x.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                 .HasKey(x => new { x.TeacherId, x.SubjectId });

            base.OnModelCreating(modelBuilder);
        }
    }
}