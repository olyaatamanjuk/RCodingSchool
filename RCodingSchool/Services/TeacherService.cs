using StudLine.Models;
using StudLine.UnitOW;
using StudLine.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudLine.Services
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

		public void DeleteTeacherFromGroup(int groupId, int teacherId)
		{
			_unitOfWork.GroupRepository.DeleteTeacherFromGroup(groupId, teacherId);
		}

		public void AddTeacherToGroup(int groupId, int teacherId)
		{
			_unitOfWork.GroupRepository.AddTeacherToGroup(groupId, teacherId);
		}

		public void DeleteTeacherFromSubject(int subjectId, int teacherId)
		{
			_unitOfWork.TeacherRepository.DeleteTeacherFromSubject(subjectId, teacherId);
		}

		public void AddTeacherToSubject(int subjectId, int teacherId)
		{
			_unitOfWork.TeacherRepository.AddTeacherToSubject(subjectId, teacherId);
		}

		public void DeleteSubjectFromGroup(int subjectId, int groupId)
		{
			_unitOfWork.GroupRepository.DeleteSubjectFromGroup(subjectId, groupId);
		}

		public void AddSubjectToGroup(int subjectId, int groupId)
		{
			_unitOfWork.GroupRepository.AddSubjectToGroup(subjectId, groupId);
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


		public List<Teacher> GetAllTeachers()
		{
			return _unitOfWork.TeacherRepository.GetAll().ToList();
		}

		public void TeacherConfigure(SubjectGroupListsVM subjectGroupList)
		{

			Teacher teacher = GetTeacherByUserId(UserId);
			if (teacher != null)
			{
				foreach (var i in subjectGroupList.Subjects)
				{
					Subject subject = _unitOfWork.SubjectRepository.Get(i.Id);
					if (i.Join == false && teacher.Subjects.FirstOrDefault(t => t.SubjectId == i.Id) != null)
					{
						DeleteTeacherFromSubject(i.Id, teacher.Id);
					}
					else if (i.Join && teacher.Subjects.FirstOrDefault(t => t.SubjectId == i.Id) == null)
					{
						AddTeacherToSubject(i.Id, teacher.Id);
					}

					foreach (var x in i.Groups)
					{
						if (x.Join)
						{
							if (subject.GroupSubject == null || subject.GroupSubject.Where(t => t.GroupId == x.Id).FirstOrDefault() == null)
							{
								AddSubjectToGroup(i.Id, x.Id);
								if (teacher.Groups.Where(t => t.GroupId == i.Id).FirstOrDefault() == null)
								{
									AddTeacherToGroup(x.Id, teacher.Id);
								}
							}
						}
						else if (!(x.Join))
						{
							if (subject.GroupSubject != null && subject.GroupSubject.Where(t => t.GroupId == x.Id).FirstOrDefault() != null) {
								DeleteSubjectFromGroup(i.Id, x.Id);
							}
						}
					}
				}

				var groups = _unitOfWork.GroupRepository.GetAll();
				foreach (var group in groups)
				{ 
					var subjectsTG = subjectGroupList.Subjects.Where(x => x.Groups.Where(t => t.Id == group.Id && t.Join == false) != null);
					if (subjectsTG != null && subjectsTG.Count() == subjectGroupList.Subjects.Count())
					{
						DeleteTeacherFromGroup(group.Id, teacher.Id);
					}
				}
			}
		}
	}
}