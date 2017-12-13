using StudLine.Models;
using System;
using System.Collections.Generic;

namespace StudLine.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetByRegisterCode(Guid registerCode);
        T GetActualUserById<T>(int id);
        bool IsTeacher(int id);
		IEnumerable<User> GetUsersByActivity(bool active);

	}
}