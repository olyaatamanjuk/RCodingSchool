using RCodingSchool.Models;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}