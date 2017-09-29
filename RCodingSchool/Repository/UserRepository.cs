
using RCodingSchool.Models;
using System.Linq;

namespace RCodingSchool.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public User GetByCredentials(string email, string password)
        {
            return dbContext.Users.FirstOrDefault(e => e.Email == email && e.Password == password);
        }

        public User GetByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(e => e.Email == email);
        }
    }
}
