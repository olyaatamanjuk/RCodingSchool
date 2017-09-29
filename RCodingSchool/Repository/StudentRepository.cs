using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}