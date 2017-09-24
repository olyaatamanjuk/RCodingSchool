using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Repository
{
	public interface IUserRepository : IRepository<User>
	{
		User GetByCredentials(string email, string password);
		User GetByEmail(string email);
	}
}