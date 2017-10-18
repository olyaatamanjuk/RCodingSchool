using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.ViewModels;
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
		private readonly IUserRepository _userRepository;


		public ChapterService(IChapterRepository chapterRepository, ITopicRepository topicRepository, IUserRepository userRepository)
		{
			_chapterRepository = chapterRepository;
			_topicRepository = topicRepository;
			_userRepository = userRepository;

		}
		public List<Chapter> GetList()
		{
			return _chapterRepository.GetAll().ToList<Chapter>();
		}
		public Topic GetTopicById(int id)
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
		public List<Chapter> GetListChaptersBySubjectId(int id)
		{
			return _chapterRepository.GetListChaptersBySubjectId(id).ToList();
		}

		public bool TrySaveTopic(TopicVM topicVM)
		{
			if (String.IsNullOrEmpty(topicVM.Name) || String.IsNullOrEmpty(topicVM.Text))
			{
				return false;
			}
			else
			{
				Topic topic = new Topic();
				topic.Name = topicVM.Name;
				topic.ChapterId = topicVM.ChapterId;
				topic.AuthorId = _userRepository.GetByEmail(HttpContext.Current.User.Identity.Name).Id;
				if (!(topicVM.Files == null))
				{
					topic.Files = topicVM.Files;
				}
				_topicRepository.Add(topic);
				_topicRepository.SaveChanges();
				return true;
			}
		}
	}
}