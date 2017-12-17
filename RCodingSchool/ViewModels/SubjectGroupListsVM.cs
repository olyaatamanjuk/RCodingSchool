using StudLine.Models;
using System.Collections.Generic;

namespace StudLine.ViewModels
{
	public class SubjectGroupListsVM
	{
		public List<SubjectVM> Subjects { get; set; }
		public List<GroupVM> AllGroups { get; set; } 
	}
}