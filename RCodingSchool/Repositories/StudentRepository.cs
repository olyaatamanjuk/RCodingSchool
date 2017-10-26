using RCodingSchool.Models;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}