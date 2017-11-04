using RCodingSchool.Models;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCodingSchool.Interfaces;
using AutoMapper;

namespace RCodingSchool.Services
{
    public class ChapterService : BaseService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IUserRepository _userRepository;
        private readonly FileService _fileService;

        public ChapterService(IChapterRepository chapterRepository, ITopicRepository topicRepository, IUserRepository userRepository,
            FileService fileService, HttpContextBase httpContext) : base(httpContext)
        {
            _chapterRepository = chapterRepository;
            _topicRepository = topicRepository;
            _userRepository = userRepository;
            _fileService = fileService;
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
                var topic = Mapper.Map<Topic>(topicVM);

                topic.AuthorId = _userRepository.GetActualUserById<Teacher>(UserId).Id;

                topic = _topicRepository.Add(topic);
                _topicRepository.SaveChanges();

                var files = _fileService.SaveImages(_httpContext.Request.Files, topic);
                foreach (var file in files)
                {
                    topic.Text = topic.Text.Replace(file.Temporary, $"/Download/{file.Id.ToString()}");
                }
                _topicRepository.SaveChanges();

                return true;
            }

            internal void AddChapter(ChapterVM chapterVM)
            {
                Chapter chapter = Mapper.Map<Chapter>(chapterVM);
                _chapterRepository.Add(chapter);
                _chapterRepository.SaveChanges();
            }
        }
    }
}