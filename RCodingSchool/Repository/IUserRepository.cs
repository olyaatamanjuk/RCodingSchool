using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}