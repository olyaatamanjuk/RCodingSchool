using RCodingSchool.EF;
using RCodingSchool.Models;

namespace RCodingSchool.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}