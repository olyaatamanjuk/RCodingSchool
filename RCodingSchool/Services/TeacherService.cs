using RCodingSchool.Interfaces;
using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
	public class TeacherService : BaseService
	{
		private readonly ITeacherRepository _teacherRepository;
		private readonly IGroupRepository _groupRepository;

		public TeacherService(ITeacherRepository teacherRepository, IGroupRepository groupRepository, HttpContextBase httpContext)
			:base(httpContext)
		{
			_teacherRepository = teacherRepository;
			_groupRepository = groupRepository;
		}

		public void DeleteGroup(int teacherId, int groupId)
		{
			_teacherRepository.DeleteGroup(teacherId, groupId);
		}

		public void AddGroup(int teacherId, int groupId)
		{
			_teacherRepository.AddGroup(teacherId, groupId);
		}

		public List<Group> GetTeacherGroups()
		{
			int teacherId = GetTeacherByUserId(UserId).Id;
			return _teacherRepository.GetTeacherGroups(teacherId);
		}

		public void AddStudentToGroup(int groupId, int studentId)
		{
			_groupRepository.AddStudentToGroup(groupId, studentId);
		}

		public void CreateGroup(string newGroupName)
		{
			Group group = new Group() { Name = newGroupName };
			_groupRepository.Add(group);
			_groupRepository.SaveChanges();
			int teacherId = GetTeacherByUserId(UserId).Id;
			_teacherRepository.AddGroup(teacherId, group.Id);
			_teacherRepository.SaveChanges();
		}

		public void DeleteStudentGroup(int groupId, int studentId)
		{
			_groupRepository.DeleteStudentFromGroup(groupId, studentId);
		}

		public Teacher GetTeacherByUserId(int id)
		{
			return _teacherRepository.GetTeacherByUserId(id);
		}

		public List<Student> GetStudentsByGroupId(int groupId)
		{
			return _groupRepository.GetStudentsByGroupId(groupId);
		}

		public List<Group> GetAllGroups()
		{
			return _groupRepository.GetAll().ToList();
		}
	}
}