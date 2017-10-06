using System.Data.Entity;

namespace RCodingSchool.Models
{
    [DbConfigurationType(typeof(App_Start.DbContextConfiguration))]
    public class RCodingSchoolContext : DbContext
    {
        //public RCodingSchoolContext(string name)
        //    : base(name)
        //{

        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherGroup>()
                .HasKey(x => new { x.GroupId, x.TeacherId });

            modelBuilder.Entity<GroupSubject>()
                .HasKey(x => new { x.GroupId, x.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                 .HasKey(x => new { x.TeacherId, x.SubjectId });

            modelBuilder.Entity<User>()
                .HasMany(x => x.Messages)
                .WithOptional(x => x.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Messages)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}