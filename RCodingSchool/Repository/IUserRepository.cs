using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByCredentials(string email, string password);
        User GetByEmail(string email);
    }
}