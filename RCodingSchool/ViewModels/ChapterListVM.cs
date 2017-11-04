using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.ViewModels
{
    public class ChaptersListVM
    {
		public List<ChapterVM> Chapters { get; set; }
		public int SubjectId { get; set; }
		public string NewChapterName { get; set; }
	}
}