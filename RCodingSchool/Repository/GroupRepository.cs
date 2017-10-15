using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Repository
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