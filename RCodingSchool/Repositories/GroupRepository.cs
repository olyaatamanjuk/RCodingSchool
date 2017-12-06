using RCodingSchool.Models;
using System.Linq;
using RCodingSchool.Interfaces;
using System;
using System.Collections.Generic;

namespace RCodingSchool.Repositories
{
	public class GroupRepository: Repository<Group>, IGroupRepository
	{
		public GroupRepository(RCodingSchoolContext context)
            : base(context)
        {
		}

		public void AddStudentToGroup(int studentId, int groupId)
		{
			Student student = dbContext.Students.Where(x => x.Id == studentId).FirstOrDefault();
			student.GroupId = groupId;
			dbContext.SaveChanges();
		}

		public void DeleteStudentFromGroup(int studentId)
		{
			Student student = dbContext.Students.Where(x => x.Id == studentId).FirstOrDefault();
			student.GroupId = null;
            dbContext.SaveChanges();
		}

		public Group GetByName( string groupName)
		{
			return dbContext.Groups.FirstOrDefault(e => e.Name == groupName);
		}

		public List<Student> GetStudentsByGroupId(int groupId)
		{
			return dbContext.Students.Where(x => x.GroupId == groupId).ToList();
		}

		public void DeleteGroup(int groupId)
		{
			List<Student> students = dbContext.Students.Where(x => x.GroupId == groupId).ToList();
			foreach (Student st in students)
			{
				st.GroupId = null;
			}

			List<TeacherGroup> teacherGroups = dbContext.TeacherGroup.Where(x => x.GroupId == groupId).ToList();
			foreach(TeacherGroup tg in teacherGroups)
			{
				dbContext.TeacherGroup.Remove(tg);
			}

			Group group = dbContext.Groups.Where(x => x.Id == groupId).FirstOrDefault();
			dbContext.Groups.Remove(group);
            dbContext.SaveChanges();
		}
	}
}