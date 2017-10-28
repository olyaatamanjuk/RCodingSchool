using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.ViewModels
{
	public class UserListsVM
	{
	//	public List<UserVM> NoActiveUsers { get; set; }
		public List<StudentVM> NoActiveStudents { get; set; }
		public List<TeacherVM> NoActiveTeachers { get; set; }
		public List<StudentVM> Students { get; set; }
		public List<TeacherVM> Teachers { get; set; }
	}
}