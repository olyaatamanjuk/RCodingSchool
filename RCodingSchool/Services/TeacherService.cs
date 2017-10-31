using RCodingSchool.Interfaces;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
	public class TeacherService
	{
		private readonly ITeacherRepository _teacherRepository;
		private readonly IGroupRepository _groupRepository;
		private HttpContextBase _httpContext;

		public TeacherService(ITeacherRepository teacherRepository, IGroupRepository groupRepository, HttpContextBase httpContext)
		{
			_teacherRepository = teacherRepository;
			_groupRepository = groupRepository;
			_httpContext = httpContext;
		}

		public void DeleteGroup(int teacherId, int groupId)
		{
			_teacherRepository.DeleteGroup(teacherId, groupId);
		}

		public void AddGroup(int teacherId, int groupId)
		{
			_teacherRepository.DeleteGroup(teacherId, groupId);
		}

		public List<Group> GetGroupsOfTeacher(int teacherId)
		{
			return _teacherRepository.GetGroupsOfTeacher(teacherId);
		}

		public void AddStudentToGroup(int groupId, int studentId)
		{
			_groupRepository.AddStudentToGroup(groupId, studentId);
		}

		public void DeleteStudentGroup(int groupId, int studentId)
		{
			_groupRepository.DeleteStudentFromGroup(groupId, studentId);
		}

		public Teacher GetTeacherByUserId(int id)
		{
			return _teacherRepository.GetTeacherByUserId(id);
		}
	}
}