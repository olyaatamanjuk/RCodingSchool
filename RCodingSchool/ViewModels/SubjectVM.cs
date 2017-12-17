using StudLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudLine.ViewModels
{
    public class SubjectVM : Entity
    {
        public string Name { get; set; }
		public string Calendar { get; set; }

		public IEnumerable<TeacherSubject> Teachers { get; set; }
		public virtual ICollection<GroupSubject> GroupSubject { get; set; }

		public List<GroupVM> Groups { get; set; }

		public bool IsExam { get; set; }
		public bool Join { get; set; }
	}
}