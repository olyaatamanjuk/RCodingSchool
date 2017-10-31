using System.Data.Entity;

namespace RCodingSchool.Models
{
	public class RCodingSchoolContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Message> Messages { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MessageGroup> MessagesGroups { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<TeacherGroup> TeacherGroup { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TeacherGroup>()
				.HasKey(x => new { x.GroupId, x.TeacherId });

			modelBuilder.Entity<GroupSubject>()
				.HasKey(x => new { x.GroupId, x.SubjectId });

			modelBuilder.Entity<TeacherSubject>()
				 .HasKey(x => new { x.TeacherId, x.SubjectId });

			modelBuilder.Entity<User>()
				.HasMany(t => t.Messages)
				.WithRequired()
				.HasForeignKey(c => c.UserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(t => t.Messages)
				.WithOptional()
				.HasForeignKey(c => c.ReceiverId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(t => t.Comments)
				.WithOptional()
				.HasForeignKey(c => c.UserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Teacher>()
				.HasMany(t => t.News)
				.WithOptional()
				.HasForeignKey(c => c.NewsAuthorId)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}