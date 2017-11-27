using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using RCodingSchool.ViewModels;
using System.Web.Helpers;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using AutoMapper;
using OfficeOpenXml;

namespace RCodingSchool.Services
{
	public class UserService : BaseService
	{
		private readonly IUserRepository _userRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly IGroupRepository _groupRepository;
		private readonly HttpContextBase _httpContext;

		public UserService(IUserRepository userRepository, IStudentRepository studentRepository,
			ITeacherRepository teacherRepository, IGroupRepository groupRepository, HttpContextBase httpContext)
			: base(httpContext)
		{
			_userRepository = userRepository;
			_studentRepository = studentRepository;
			_teacherRepository = teacherRepository;
			_groupRepository = groupRepository;
			_httpContext = httpContext;
		}

		public bool TryLogin(UserVM loginCreds, out User user)
		{
			user = _userRepository.GetByEmail(loginCreds.Email);

			if (user == null)
			{
				user = null;
				return false;
			}
			else
			{
				if (!user.RegisterCode.Equals(Guid.Empty))
				{
					user = null;
					return false;
				}

				if (!string.Equals(user.Password, Crypto.SHA256(loginCreds.Password)))
				{
					user = null;
					return false;
				}

				return true;
			}
		}

		public User GetUserByEmail(string email)
		{
			return _userRepository.GetByEmail(email);
		}

		public User RegisterNew(UserVM userVM)
		{
			User user = new User
			{
				Email = userVM.Email,
				FirstName = userVM.FirstName,
				LastName = userVM.LastName,
				Password = Crypto.SHA256(userVM.Password),
				RegisterCode = Guid.NewGuid(),
				IsActive = false
			};

			if (!SendEmail(user.Email, user.RegisterCode))
			{
				return null;
			}

			_userRepository.Add(user);

			if (userVM.IsTeacher)
			{
				Teacher teacher = new Teacher
				{
					User = user
				};
				_teacherRepository.Add(teacher);
				_teacherRepository.SaveChanges();
			}
			else
			{
				Student student = new Student
				{
					Group = _groupRepository.Get(userVM.GroupId),
					User = user
				};
				_studentRepository.Add(student);
				_studentRepository.SaveChanges();
			}

			return null;
		}

		public void FinishRegister(Guid registerCode)
		{
			var user = _userRepository.GetByRegisterCode(registerCode);

			if (user == null)
			{
				throw new Exception("User with this register code do not exists");
			}

			user.RegisterCode = Guid.Empty;

			_userRepository.SaveChanges();
		}

		public bool CheckValidation(UserVM userVM, bool editing = false)
		{
			bool isValid = true;

			try
			{
				MailAddress email = new MailAddress(userVM.Email);
			}
			catch (Exception)
			{
				isValid = false;
			}

			if (editing)
			{
				if (userVM.Password != userVM.ConfirmPassword)
				{
					isValid = false;
				}
			}
			else
			{
				if (string.IsNullOrWhiteSpace(userVM.Password)
					|| string.IsNullOrWhiteSpace(userVM.ConfirmPassword)
					|| userVM.Password != userVM.ConfirmPassword)
				{
					isValid = false;
				}
			}
			return isValid;
		}

		public List<Group> GetGroups()
		{
			return _groupRepository.GetAll().ToList();
		}

		public T GetActualUserById<T>(int id)
		{
			return _userRepository.GetActualUserById<T>(id);
		}

		private bool SendEmail(string email, Guid registerCode)
		{
			try
			{
				var url = "http://" + _httpContext.Request.Url.Authority + "/account/registerConfirm?registerCode=" + registerCode.ToString();

				SmtpClient client = new SmtpClient("smtp.gmail.com", 587); // Check
				client.Credentials = new NetworkCredential("emailvalidationsender@gmail.com", "pas12word");
				client.EnableSsl = true;

				var mailFrom = new MailAddress("emailvalidationsender@gmail.com");
				var mailTo = new MailAddress(email);
				MailMessage message = new MailMessage(mailFrom, mailTo);
				message.Subject = "No-reply registration message";
				message.IsBodyHtml = true;
				message.Body = string.Format(System.IO.File.ReadAllText(_httpContext.Server.MapPath("~/Templates/confirm-register.html")), url);
				client.Send(message);

				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool IsTeacher(int id)
		{
			return _userRepository.IsTeacher(id);
		}

		public List<Teacher> GetTeachers(bool active)
		{
			List<User> usersList = _userRepository.GetUsersByActivity(active).ToList();
			List<Teacher> teacherList = new List<Teacher>();
			foreach (var x in usersList)
			{
				var user = _userRepository.GetActualUserById<Teacher>(x.Id);
				if (!(user == null))
				{
					teacherList.Add(user);
				}
			}
			return teacherList;
		}

		public List<Student> GetStudents(bool active)
		{
			List<User> usersList = _userRepository.GetUsersByActivity(active).ToList();
			List<Student> studentList = new List<Student>();
			foreach (var x in usersList)
			{
				var user = _userRepository.GetActualUserById<Student>(x.Id);
				if (!(user == null))
				{
					studentList.Add(user);
				}
			}
			return studentList;
		}

		public List<User> GetUsersByActivity(bool active)
		{
			return _userRepository.GetUsersByActivity(active).ToList();
		}

		public void SaveStudentChanges(List<StudentVM> listStudentVM)
		{
			foreach (StudentVM x in listStudentVM)
			{
				Student student = _studentRepository.Get(x.Id);

				if (_userRepository.Get(UserId).isAdmin)
				{
					if (x.MarkForDelete)
					{
						_studentRepository.Remove(student);
					}
					else
					{
						student.User.isAdmin = x.User.isAdmin;
					}
				}

				student.User.IsActive = x.User.IsActive;
				if (!(x.newGroupId == 0))
				{
					student.GroupId = x.newGroupId;
				}
			}
			_studentRepository.SaveChanges();
		}

		public void SaveTeacherChanges(List<TeacherVM> listTeacherVM)
		{
			foreach (TeacherVM x in listTeacherVM)
			{
				Teacher teacher = _teacherRepository.Get(x.Id);
				teacher.User.IsActive = x.User.IsActive;

				if (_userRepository.Get(UserId).isAdmin)
				{
					if (x.MarkForDelete)
					{
						_teacherRepository.Remove(teacher);
					}
					else
					{
						teacher.User.isAdmin = x.User.isAdmin;
					}
				}
			}
			_teacherRepository.SaveChanges();
		}

		public bool TrySaveUsersFromFile(HttpPostedFileBase file, bool isItTeachers)
		{
			string fileName = file.FileName;
			string fileContentType = file.ContentType;
			byte[] fileBytes = new byte[file.ContentLength];
			var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
			var teachersList = new List<Teacher>();
			var studentsList = new List<Student>();

			try
			{
				using (var package = new ExcelPackage(file.InputStream))
				{
					var currentSheet = package.Workbook.Worksheets;
					var workSheet = currentSheet.First();
					var noOfCol = workSheet.Dimension.End.Column;
					var noOfRow = workSheet.Dimension.End.Row;

					int noEmailCol = 0;
					int noFirstNameCol = 0;
					int noLastNameCol = 0;
					int noGroupNameCol = 0;

					for (int i = 1; i <= noOfCol; i++)
					{
						string colName = workSheet.Cells[1, i].Value.ToString();
						switch (colName)
						{
							case "Email":
								noEmailCol = i;
								break;
							case "FirstName":
								noFirstNameCol = i;
								break;
							case "LastName":
								noLastNameCol = i;
								break;
							case "Group":
								noGroupNameCol = i;
								break;
							default:
								break;
						}
					}

					if (noEmailCol == 0 || noFirstNameCol == 0 || noLastNameCol == 0 || noGroupNameCol == 0)
					{
						return false;
					}

					for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
					{
						var user = new User();
						user.FirstName = workSheet.Cells[rowIterator, noFirstNameCol].Value.ToString();
						user.LastName = workSheet.Cells[rowIterator, noLastNameCol].Value.ToString();
						user.Email = workSheet.Cells[rowIterator, noEmailCol].Value.ToString();
						if (String.IsNullOrWhiteSpace(user.Email))
						{
							continue;
						}

						user.Password = Crypto.SHA256(System.Web.Security.Membership.GeneratePassword(10, 0));
						user.IsActive = true;
						_userRepository.Add(user);
						_userRepository.SaveChanges();

						if (isItTeachers)
						{
							Teacher teacher = new Teacher()
							{
								UserId = user.Id
							};

							teachersList.Add(teacher);
						}
						else
						{
							string groupName = workSheet.Cells[rowIterator, noGroupNameCol].Value.ToString();
							Group group = new Group();
							if (!String.IsNullOrWhiteSpace(groupName))
							{
								group = _groupRepository.GetByName(groupName);
								if (group == null)
								{
									group = AddGroup(groupName);
								}
							}
							else
							{
								group = AddGroup(groupName);
							}
							Student student = new Student()
							{
								GroupId = group.Id,
								UserId = user.Id
							};

							studentsList.Add(student);
						}
					}
					_studentRepository.AddRange(studentsList);
					_studentRepository.SaveChanges();
					_teacherRepository.AddRange(teachersList);
					_teacherRepository.SaveChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public Group AddGroup(string name)
		{
			Group group = new Group()
			{
				Name = name
			};
			_groupRepository.Add(group);
			_groupRepository.SaveChanges();
			return group;
		}

		public bool TryEditUser(UserVM userVM)
		{
			User user = _userRepository.Get(userVM.Id);
			if (user == null)
			{
				return false;
			}
			else
			{
				user.FirstName = userVM.FirstName;
				user.LastName = userVM.LastName;
				user.Email = userVM.Email;
				if (!String.IsNullOrWhiteSpace(userVM.ConfirmPassword))
				{
					user.Password = Crypto.SHA256(userVM.Password);
				}
				_userRepository.SaveChanges();

				return true;
			}
		}

		public User Get(int id)
		{
			return _userRepository.Get(id);
		}
	}
}