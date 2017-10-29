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

namespace RCodingSchool.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly HttpContextBase _httpContext;

        public UserService(IUserRepository userRepository, IStudentRepository studentRepository,
            ITeacherRepository teacherRepository, IGroupRepository groupRepository, HttpContextBase httpContext)
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

        public bool CheckValidation(UserVM userVM)
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

            if (string.IsNullOrWhiteSpace(userVM.Password)
                || string.IsNullOrWhiteSpace(userVM.ConfirmPassword)
                || userVM.Password != userVM.ConfirmPassword)
            {
                isValid = false;
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

		public List <User> GetUsersByActivity(bool active)
		{
			return _userRepository.GetUsersByActivity(active).ToList();
		}

	}
}