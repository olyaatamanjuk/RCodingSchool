using RCodingSchool.Models;
using RCodingSchool.Repository;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RCodingSchool.Services
{
    public class ChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUserRepository _userRepository;
        private HttpContextBase _httpContext;


        public ChapterService(IChapterRepository chapterRepository, ITopicRepository topicRepository, IUserRepository userRepository,
            HttpContextBase httpContext)
        {
            _chapterRepository = chapterRepository;
            _topicRepository = topicRepository;
            _userRepository = userRepository;
            _httpContext = httpContext;
        }
        public List<Chapter> GetList()
        {
            return _chapterRepository.GetAll().ToList();
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

        public Chapter GetById(int id)
        {
            return _chapterRepository.Get(id);
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
                Topic topic = new Topic
                {
                    Name = topicVM.Name,
                    Text = topicVM.Text,
                    ChapterId = topicVM.ChapterId,
                    AuthorId = _userRepository.GetActualUserById<Teacher>(UserId).Id
                };

                if (!(topicVM.Files == null))
                {
                    topic.Files = topicVM.Files;
                }

                _topicRepository.Add(topic);
                _topicRepository.SaveChanges();

                return true;
            }
        }

        // To Base service
        public int UserId
        {
            get
            {
                return int.Parse(((ClaimsIdentity)_httpContext.User.Identity).Claims.FirstOrDefault(x => x.Type == "id").Value);
            }
            private set { }
        }
    }
}