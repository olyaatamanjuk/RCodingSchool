using RCodingSchool.Models;
using System.Linq;
using RCodingSchool.Interfaces;

namespace RCodingSchool.Repositories
{
	public class GroupRepository: Repository<Group>, IGroupRepository
	{
		public GroupRepository(RCodingSchoolContext context)
            : base(context)
        {
		}

		public Group GetByName( string groupName)
		{
			return dbContext.Groups.FirstOrDefault(e => e.Name == groupName);
		}
	}
}