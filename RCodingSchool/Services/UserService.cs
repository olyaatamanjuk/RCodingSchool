using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.ViewModels;
using System.Web.Helpers;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;

namespace RCodingSchool.Services
{
    public class UserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly IGroupRepository _groupRepository;

		public UserService(IUserRepository userRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository, IGroupRepository groupRepository)
		{
			_userRepository = userRepository;
			_studentRepository = studentRepository;
			_teacherRepository = teacherRepository;
			_groupRepository = groupRepository;
		}

        public bool TryLogin(UserVM loginCreds, out User user)
        {
            user = _userRepository.GetByEmail(loginCreds.Email);

            if (user == null)
            {
                user = null;
                return false;
            }

			if (!string.Equals(user.Password, EncryptPassword(loginCreds.Password)))
			{
				user = null;
				return false;
			}

			return true;
        }

		public User GetUserByEmail (string email)
		{
			return _userRepository.GetByEmail(email);
		}

        public string EncryptPassword (string password)
        {
            return Crypto.SHA256(password);
        }
		public User RegisterNew(UserVM userVM)
		{
			User user = new User
			{
				Email = userVM.Email,
				FirstName = userVM.FirstName,
				LastName = userVM.LastName,
				Password = Crypto.SHA256(userVM.Password)
			};
			_userRepository.Add(user);
			_userRepository.SaveChanges();

			if (userVM.IsTeacher)
			{
				Teacher teacher = new Teacher
				{
					Email = userVM.Email,
					FirstName = userVM.FirstName,
					LastName = userVM.LastName,
					Password = Crypto.SHA256(userVM.Password),
					User = user
				};
				_teacherRepository.Add(teacher);
				_teacherRepository.SaveChanges();
			}
			else
			{
				Student student = new Student
				{
					Email = userVM.Email,
					FirstName = userVM.FirstName,
					LastName = userVM.LastName,
					Group = _groupRepository.GetByName(userVM.GroupName),
					Password = Crypto.SHA256(userVM.Password),
					User = user
				};
				_studentRepository.Add(student);
				_studentRepository.SaveChanges();
			}
			return user;
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
	}
}