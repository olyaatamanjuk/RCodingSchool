using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Collections.Generic;

namespace RCodingSchool.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(RCodingSchoolContext context)
            : base(context)
        {
        }

        public override IEnumerable<Student> GetAll()
        {
            return dbContext.Students.Include("Group");
        }
    }
}