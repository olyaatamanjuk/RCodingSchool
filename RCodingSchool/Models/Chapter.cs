﻿using RCodingSchool.ViewModels;
using System.Collections.Generic;

namespace RCodingSchool.Models
{
    public class Chapter : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}