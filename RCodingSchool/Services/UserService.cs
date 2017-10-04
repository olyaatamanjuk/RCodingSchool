using RCodingSchool.Models;
using RCodingSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public User GetUserByEmail (string email)
		{
			return _userRepository.GetByEmail(email);
		}
	}
}