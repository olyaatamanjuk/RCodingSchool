using RCodingSchool.Models;

namespace RCodingSchool.ViewModels
{
    public class MessageVM : Entity
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public int ReceiverId { get; set; }
    }
}