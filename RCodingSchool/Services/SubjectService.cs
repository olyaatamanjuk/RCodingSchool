using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using System.Collections.Generic;
using System.Linq;

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