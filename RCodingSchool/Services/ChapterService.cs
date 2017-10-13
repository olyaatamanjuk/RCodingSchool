using RCodingSchool.Models;
using RCodingSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
    public class ChapterService
    {
        private readonly IChapterRepository _chapterRepository;


        public ChapterService(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }
        public List<Chapter> GetList()
        {
            return _chapterRepository.GetAll().ToList<Chapter>();
        }
    }
}