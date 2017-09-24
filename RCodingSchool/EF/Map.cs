using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RCodingSchool.EF
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			ToTable("Users", "smp").HasKey(t => t.Id);
			Property(t => t.Email).HasMaxLength(128).IsRequired();
			Property(t => t.Password).HasMaxLength(128).IsRequired();
			Property(t => t.FirstName).HasMaxLength(64);
			Property(t => t.LastName).HasMaxLength(64);
		}
	}

	public class TeacherMap : EntityTypeConfiguration<Teacher>
	{
	/*	public TeacherMap()
		{
			ToTable("Teachers", "smp").HasKey(t => t.Id);
			.HasMany(e = > e.Groups)
			.WithMany(p = > p.Teachers)
				.Map(
					m = > {
				m.MapLeftKey("TeacherId");
				m.MapRightKey("GroupId");
				m.ToTable("TeacherGroup");
			});
		}*/
	}

}