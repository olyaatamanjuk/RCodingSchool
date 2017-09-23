using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
    public class CodingSchoolContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
	}
}