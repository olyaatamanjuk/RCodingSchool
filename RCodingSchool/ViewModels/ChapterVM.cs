using RCodingSchool.Models;
using System.Collections.Generic;

namespace RCodingSchool.ViewModels
{
    public class ChapterVM: Entity
    {
        public string Name { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}