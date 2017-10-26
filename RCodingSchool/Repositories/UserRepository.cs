using RCodingSchool.Models;
using System;
using System.Linq;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public T GetActualUserById<T>(int id)
        {
            object result = null;

            if (typeof(T).Equals(typeof(Teacher)))
            {
                result = dbContext.Teachers.Include("User").Include("Groups.Group").Include("Subjects.Subject").FirstOrDefault(x => x.UserId == id);
            }
            else
            {
                result = dbContext.Students.Include("Group").FirstOrDefault(x => x.UserId == id);
            }

            return (T)result;
        }

        public User GetByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
        }

        public User GetByRegisterCode(Guid registerCode)
        {
            return dbContext.Users.FirstOrDefault(x => x.RegisterCode.Equals(registerCode));
        }

        public bool IsTeacher(int id)
        {
            Teacher teacher = dbContext.Teachers.FirstOrDefault(x => x.UserId == id);
            if (teacher == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
