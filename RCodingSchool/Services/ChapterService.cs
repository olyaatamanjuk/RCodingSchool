using StudLine.Models;
using StudLine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudLine.UnitOW;

namespace StudLine.Services
{
    public class ChapterService : BaseService
    {
        public IUnitOfWork _unitOfWork;
        private readonly FileService _fileService;

        public ChapterService(IUnitOfWork unitOfWork, FileService fileService, HttpContextBase httpContext)
            : base(httpContext)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public List<Chapter> GetList()
        {
            return _unitOfWork.ChapterRepository.GetAll().ToList();
        }

        public Topic GetTopicById(int id)
        {
            return _unitOfWork.TopicRepository.Get(id);
        }

        public Topic GetFirstTopicFromChaper(int id)
        {
            return _unitOfWork.TopicRepository.GetFirstFromChapter(id);
        }

        public Chapter GetFirstChapter()
        {
            return _unitOfWork.ChapterRepository.GetFirst();
        }

        public Chapter GetById(int id)
        {
            return _unitOfWork.ChapterRepository.Get(id);
        }

        public List<Chapter> GetListChaptersBySubjectId(int id)
        {
            return _unitOfWork.ChapterRepository.GetListChaptersBySubjectId(id).ToList();
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

                topic.AuthorId = _unitOfWork.UserRepository.GetActualUserById<Teacher>(UserId).Id;

                topic = _unitOfWork.TopicRepository.Add(topic);
                _unitOfWork.SaveChanges();
                var files = _fileService.SaveImages(_httpContext.Request.Files, topic.Id);
                foreach (var file in files)
                {
                    topic.Text = topic.Text.Replace(file.Temporary, $"/Download/File/{file.Id.ToString()}");
                }
                _unitOfWork.SaveChanges();

                return true;
            }
        }

        public void AddChapter(ChapterVM chapterVM)
        {
            Chapter chapter = Mapper.Map<Chapter>(chapterVM);
            _unitOfWork.ChapterRepository.Add(chapter);
            _unitOfWork.SaveChanges();
        }

        public bool TryEditTopic(TopicVM topic)
        {
            if (String.IsNullOrEmpty(topic.Name) || String.IsNullOrEmpty(topic.Text))
            {
                return false;
            }
            else
            {
                _fileService.DeleteImages(topic);

                var newFiles = _fileService.SaveImages(_httpContext.Request.Files, topic.Id);
                foreach (var file in newFiles)
                {
                    topic.Text = topic.Text.Replace(file.Temporary, $"/Download/File/{file.Id}");
                }

                Topic originalTopic = GetTopicById(topic.Id);
                originalTopic.Name = topic.Name;
                originalTopic.Text = topic.Text;
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public void RemoveTopic(int id)
        {
            var topic = _unitOfWork.TopicRepository.Get(id);
            _fileService.RemoveImages(id);
            _unitOfWork.TopicRepository.Remove(topic);
            _unitOfWork.SaveChanges();
        }

		public void RemoveChapter(int id)
		{
			var chapter = _unitOfWork.ChapterRepository.Get(id);
			if (chapter != null && chapter.Topics.Count> 0)
			{
				List< Topic>topics = chapter.Topics.ToList();
				for (int i = 0; i< topics.Count; i++)
				{
					RemoveTopic(topics[i].Id);
				}
			}
			_unitOfWork.ChapterRepository.Remove(chapter);
			_unitOfWork.SaveChanges();
		}

		public void EditChapter(int id, string newName)
		{
			var chapter = _unitOfWork.ChapterRepository.Get(id);
			if (!(String.IsNullOrWhiteSpace(newName)))
			{
				chapter.Name = newName;
			}
			_unitOfWork.SaveChanges();
		}
	}
}