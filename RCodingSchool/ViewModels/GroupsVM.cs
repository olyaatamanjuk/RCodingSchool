using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.ViewModels
{
	public class GroupsVM
	{
		public List<GroupVM> GroupList { get; set; }
		public string NewGroupName { get; set; }
		public bool MyGroups { get; set; }
	}
}