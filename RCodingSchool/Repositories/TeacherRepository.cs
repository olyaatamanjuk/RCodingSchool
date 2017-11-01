using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RCodingSchool.Repositories
{
	public class TeacherRepository : Repository<Teacher>, ITeacherRepository
	{
		public TeacherRepository(RCodingSchoolContext context)
			: base(context)
		{
		}

		public void AddGroup(int teacherId, int groupId)
		{
			TeacherGroup teacherGroup = new TeacherGroup()
			{
				TeacherId = teacherId,
				GroupId = groupId
			};
			dbContext.TeacherGroup.Add(teacherGroup);
		}

		public void DeleteGroup(int teacherId, int groupId)
		{
			TeacherGroup teacherGroup = dbContext.TeacherGroup.Where(x => x.TeacherId == teacherId && x.GroupId == groupId).FirstOrDefault();
			dbContext.TeacherGroup.Remove(teacherGroup);
		}

		public List<Group> GetTeacherGroups(int teacherId)
		{
			IEnumerable<TeacherGroup> teacherGroups = dbContext.TeacherGroup.Where(x => x.TeacherId == teacherId);
			List<Group> groups = new List<Group>();
			foreach (var x in teacherGroups)
			{
				Group group = dbContext.Groups.Where(i => i.Id == x.GroupId).FirstOrDefault();
				if (!(group == null)){
					groups.Add(group);
				}
			}
			return groups;
		}

		public Teacher GetTeacherByUserId(int userId)
		{
			return dbContext.Teachers.Where(x => x.UserId == userId).FirstOrDefault();
		}
	}
}