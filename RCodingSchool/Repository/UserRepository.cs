using RCodingSchool.Models;
using RCodingSchool.UnitOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Repository
{
		public class UserRepository : Repository<User>, IUserRepository
		{
			public UserRepository(IUnitOfWork context) : base(context)
			{
			}
			public User GetByCredentials(string email, string password)
			{
				return _unitOfWork.Context.Users
					.Where(e => e.Email == email && e.Password == password)
					.FirstOrDefault<User>();
			}
			public User GetByEmail(string email)
			{
				return _unitOfWork.Context.Users
					.Where(e => e.Email == email)
					.FirstOrDefault<User>();
			}
		}
	}
