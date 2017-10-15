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
		private readonly ITopicRepository _topicRepository;


		public ChapterService(IChapterRepository chapterRepository, ITopicRepository topicRepository)
        {
            _chapterRepository = chapterRepository;
			_topicRepository = topicRepository;

		}
        public List<Chapter> GetList()
        {
            return _chapterRepository.GetAll().ToList<Chapter>();
        }
		public Topic GetTopicById (int id)
		{
			return _topicRepository.Get(id);
		}
		
		public Topic GetFirstTopicFromChaper(int id)
		{
			return _topicRepository.GetFirstFromChapter(id);
		}

		public Chapter GetFirstChapter()
		{
			return _chapterRepository.GetFirst();
		}
	}
}