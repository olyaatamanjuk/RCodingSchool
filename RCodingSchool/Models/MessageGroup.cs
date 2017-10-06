using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class MessageGroup : Entity
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}