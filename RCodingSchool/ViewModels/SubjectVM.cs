﻿using RCodingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.ViewModels
{
    public class SubjectVM : Entity
    {
        public string Name { get; set; }

        public IEnumerable<TeacherSubject> Teachers { get; set; }
        public IEnumerable<GroupSubject> GroupSubject { get; set; }
        public bool IsExam { get; set; }
    }
}