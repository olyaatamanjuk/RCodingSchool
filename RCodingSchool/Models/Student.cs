﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Models
{
    public class Student : Entity
    {
		public int GroupId { get; set; }
		public int UserId { get; set; }
	}
}