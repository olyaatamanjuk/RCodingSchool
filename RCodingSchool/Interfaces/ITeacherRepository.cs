using StudLine.Models;
using System.Collections;
using System.Collections.Generic;

namespace StudLine.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
		void DeleteGroup(int teacherId, int groupId);
		void AddGroup(int teacherId, int groupId);
		List <Group> GetTeacherGroups(int teacherId);
		Teacher GetTeacherByUserId(int Id);
		void DeleteTeacherFromSubject(int subjectId, int teacherId);
		void AddTeacherToSubject(int subjectId, int teacherId);
	}
}