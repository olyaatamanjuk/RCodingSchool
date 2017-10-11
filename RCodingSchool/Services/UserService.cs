using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.ViewModels;
using System.Web.Helpers;

namespace RCodingSchool.Services
{
    public class UserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

        public bool TryLogin(UserVM loginCreds, out User user)
        {
            user = _userRepository.GetByEmail(loginCreds.Email);

            if (user == null)
            {
                user = null;
                return false;
            }

			//// TODO: Check this shit encrypting right way (ctrl + d + q)
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
	}
}