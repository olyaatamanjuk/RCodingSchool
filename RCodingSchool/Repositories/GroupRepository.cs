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
			SaveChanges();
		}

		public void DeleteStudentFromGroup(int studentId, int groupId)
		{
			Student student = dbContext.Students.Where(x => x.Id == studentId).FirstOrDefault();
			student.GroupId = null;
			SaveChanges();
		}

		public Group GetByName( string groupName)
		{
			return dbContext.Groups.FirstOrDefault(e => e.Name == groupName);
		}

		public List<Student> GetStudentsByGroupId(int groupId)
		{
			return dbContext.Students.Where(x => x.GroupId == groupId).ToList();
		}
	}
}