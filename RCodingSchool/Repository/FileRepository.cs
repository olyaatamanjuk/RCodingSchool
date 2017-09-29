using RCodingSchool.Models;


namespace RCodingSchool.Repository
{
    public class FileRepository :Repository<File>, IFileRepository
    {
        public FileRepository(RCodingSchoolContext context)
            : base(context)
        {
        }
    }
}