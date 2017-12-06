using RCodingSchool.Models;
using RCodingSchool.UnitOW;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
	public class TeacherService : BaseService
	{
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork, HttpContextBase httpContext)
			:base(httpContext)
		{
            _unitOfWork = unitOfWork;
        }

		public void DeleteGroup(int teacherId, int groupId)
		{
            _unitOfWork.TeacherRepository.DeleteGroup(teacherId, groupId);
		}

		public void AddGroup(int teacherId, int groupId)
		{
            _unitOfWork.TeacherRepository.AddGroup(teacherId, groupId);
		}

		public List<Group> GetTeacherGroups()
		{
			int teacherId = GetTeacherByUserId(UserId).Id;
			return _unitOfWork.TeacherRepository.GetTeacherGroups(teacherId);
		}

		public void AddStudentToGroup(int groupId, int studentId)
		{
			_unitOfWork.GroupRepository.AddStudentToGroup(groupId, studentId);
		}

		public void CreateGroup(string newGroupName)
		{
			Group group = new Group() { Name = newGroupName };
            _unitOfWork.GroupRepository.Add(group);
            _unitOfWork.SaveChanges();
			int teacherId = GetTeacherByUserId(UserId).Id;
            _unitOfWork.TeacherRepository.AddGroup(teacherId, group.Id);
            _unitOfWork.SaveChanges();
		}

		public void DeleteStudentGroup(int studentId)
		{
            _unitOfWork.GroupRepository.DeleteStudentFromGroup(studentId);
		}

		public void DeleteGroup(int groupId)
		{
            _unitOfWork.GroupRepository.DeleteGroup(groupId);
		}

		public Teacher GetTeacherByUserId(int id)
		{
			return _unitOfWork.TeacherRepository.GetTeacherByUserId(id);
		}

		public List<Student> GetStudentsByGroupId(int groupId)
		{
			return _unitOfWork.GroupRepository.GetStudentsByGroupId(groupId);
		}

		public List<Group> GetAllGroups()
		{
			return _unitOfWork.GroupRepository.GetAll().ToList();
		}
	}
}