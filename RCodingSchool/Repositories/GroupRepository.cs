using StudLine.Models;
using System.Linq;
using StudLine.Interfaces;
using System;
using System.Collections.Generic;

namespace StudLine.Repositories
{
	public class GroupRepository: Repository<Group>, IGroupRepository
	{
		public GroupRepository(StudLineContext context)
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

		public void DeleteTeacherFromGroup(int groupId, int teacherId)
		{
			TeacherGroup tg =  dbContext.TeacherGroup.Where(x => x.GroupId == groupId && x.TeacherId == teacherId).FirstOrDefault();
			if (tg != null)
			{
				dbContext.TeacherGroup.Remove(tg);
				dbContext.SaveChanges();
			}
		}

		public void AddTeacherToGroup(int groupId, int teacherId)
		{
			if (dbContext.TeacherGroup.Where(x => x.GroupId == groupId && x.TeacherId == teacherId).FirstOrDefault() == null)
			{
				TeacherGroup tg = new TeacherGroup()
				{
					GroupId = groupId,
					TeacherId = teacherId
				};

				dbContext.TeacherGroup.Add(tg);
				dbContext.SaveChanges();
			}
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

		public void DeleteSubjectFromGroup(int subjectId, int groupId)
		{
			GroupSubject gs = dbContext.GroupSubject.Where(x => x.SubjectId == subjectId && x.GroupId == groupId).FirstOrDefault();
			if(gs != null)
			{
				dbContext.GroupSubject.Remove(gs);
				dbContext.SaveChanges();
			}
		}

		public void AddSubjectToGroup(int subjectId, int groupId)
		{
			if (dbContext.GroupSubject.Where(x => x.SubjectId == subjectId && x.GroupId == groupId).FirstOrDefault() == null)
			{
				GroupSubject gs = new GroupSubject()
				{
					SubjectId = subjectId,
					GroupId = groupId
				};

				dbContext.GroupSubject.Add(gs);
				dbContext.SaveChanges();
			}
		}
	}
}