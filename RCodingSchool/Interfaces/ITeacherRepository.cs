using RCodingSchool.Models;
using System.Collections;
using System.Collections.Generic;

namespace RCodingSchool.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
		void DeleteGroup(int teacherId, int groupId);
		void AddGroup(int teacherId, int groupId);
		List <Group> GetTeacherGroups(int teacherId);
		Teacher GetTeacherByUserId(int Id);
	}
}