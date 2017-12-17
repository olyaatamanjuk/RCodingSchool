using StudLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudLine.Interfaces
{
	public interface IGroupRepository : IRepository<Group>
	{
		Group GetByName(string groupName);
		void AddStudentToGroup(int studentId, int groupId);
		void DeleteStudentFromGroup(int studentId);
		List<Student> GetStudentsByGroupId(int groupId);
		void DeleteGroup(int groupId);
		void DeleteTeacherFromGroup(int groupId, int teacherId);
		void AddTeacherToGroup(int groupId, int teacherId);
		void DeleteSubjectFromGroup(int subjectId, int groupId);
		void AddSubjectToGroup(int subjectId, int groupId);
	}
}