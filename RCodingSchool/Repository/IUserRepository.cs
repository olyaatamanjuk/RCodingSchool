using RCodingSchool.Models;
using System;

namespace RCodingSchool.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetByRegisterCode(Guid registerCode);
    }
}