using RCodingSchool.Models;
using System;

namespace RCodingSchool.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetByRegisterCode(Guid registerCode);
        T GetActualUserById<T>(int id);
        bool IsTeacher(int id);
    }
}