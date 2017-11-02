namespace RCodingSchool.Models
{
    public class File: Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual Topic Topic { get; set; }
        public int? TopicId { get; set; }

		public virtual Task Task{ get; set; }
		public int? TaskId { get; set; }
	}
}