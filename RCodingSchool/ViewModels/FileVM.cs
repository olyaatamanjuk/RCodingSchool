using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
{
    public class FileVM: Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual Topic Topic { get; set; }
        public int? TopicId { get; set; }

		public virtual Task Task{ get; set; }
		public int? TaskId { get; set; }

		public virtual DoneTask DoneTask { get; set; }
		public int? DoneTaskId { get; set; }

		public string Temporary { get; set; }
	}
}