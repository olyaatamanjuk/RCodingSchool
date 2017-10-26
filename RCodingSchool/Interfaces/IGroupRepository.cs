using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Interfaces
{
	public interface IGroupRepository: IRepository<Group>
	{
		Group GetByName(string groupName);
	}
}