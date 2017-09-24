using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Mapping.ModelsVM
{
	public class MessageVM: Entity
	{
		public int UserId { get; set; }
		public string Text { get; set; }
		public int ReceiverId { get; set; }
	}
}