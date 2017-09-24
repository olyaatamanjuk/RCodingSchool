using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RCodingSchool.EF
{
	public class RCodingSchoolContext: DbContext
	{
        public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Group> Groups { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			/*(modelBuilder.Entity<Teacher>().HasMany(p => p.Groups).WithMany();
			modelBuilder.Entity<Teacher>().HasMany(p => p.Groups).WithMany



			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new TeacherMap());
			modelBuilder.Configurations.Add(new GroupMap());
			modelBuilder.Configurations.Add(new StudentMap());
			modelBuilder.Configurations.Add(new TopicMap());
			modelBuilder.Configurations.Add(new ChapterMap());*/
		}
	}

}