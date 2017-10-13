using RCodingSchool.Models;
using RCodingSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
    public class SubjectService
    {
        private readonly ISubjectRepository _subjectRepository;


        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public List<Subject> GetList()
        {
           return _subjectRepository.GetAll().ToList<Subject>();
        }
    }
}