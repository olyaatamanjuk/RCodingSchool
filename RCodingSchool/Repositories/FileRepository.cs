using RCodingSchool.Models;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
    public class FileRepository :Repository<File>, IFileRepository
    {
        public FileRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}