using RCodingSchool.Models;
using System;
using System.Linq;

namespace RCodingSchool.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
        }

        public User GetByRegisterCode(Guid registerCode)
        {
            return dbContext.Users.FirstOrDefault(x => x.RegisterCode.Equals(registerCode));
        }
    }
}
