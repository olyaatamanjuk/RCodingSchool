using StudLine.Models;
using StudLine.Interfaces;
using System.Collections.Generic;

namespace StudLine.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudLineContext context)
            : base(context)
        {
        }

        public override IEnumerable<Student> GetAll()
        {
            return dbContext.Students.Include("Group");
        }
    }
}