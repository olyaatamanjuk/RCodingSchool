using RCodingSchool.Models;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}