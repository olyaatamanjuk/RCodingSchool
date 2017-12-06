using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.UnitOW;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace RCodingSchool.Services
{
    public class NewsService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork, HttpContextBase httpContext)
            : base(httpContext)
        {
            _unitOfWork = unitOfWork;
        }

        public News Get(int id)
        {
            return _unitOfWork.NewsRepository.Get(id);
        }

        public bool TrySave(NewsVM newsVM)
        {
            if (String.IsNullOrEmpty(newsVM.CommentText))
            {
                return false;
            }
            else
            {
                Comment comment = new Comment()
                {
                    UserId = this.UserId,
                    Text = newsVM.CommentText,
                    NewsId = newsVM.Id,
                    Date = DateTime.Now
                };
                _unitOfWork.CommentRepository.Add(comment);
                _unitOfWork.SaveChanges();
            }
            return true;
        }

        public IEnumerable<News> GetAll()
        {
            return _unitOfWork.NewsRepository.GetAll();
        }

        public bool TrySaveNews(NewsVM newsVM)
        {
            News news = Mapper.Map<News>(newsVM);
            if (!String.IsNullOrWhiteSpace(news.Title) && !String.IsNullOrWhiteSpace(news.Description))
            {
                news.Date = DateTime.Now;
                news.NewsAuthorId = _unitOfWork.UserRepository.GetActualUserById<Teacher>(UserId).Id;
                _unitOfWork.NewsRepository.Add(news);
                _unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryEditNews(NewsVM newsVM)
        {

            if (!String.IsNullOrWhiteSpace(newsVM.Title) && !String.IsNullOrWhiteSpace(newsVM.Description))
            {
                News news = Get(newsVM.Id);
                news.Title = newsVM.Title;
                news.Description = newsVM.Description;
                _unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveNews(int id)
        {
            News news = Get(id);
            _unitOfWork.NewsRepository.Remove(news);
            _unitOfWork.SaveChanges();
        }

        public void RemoveComment(int id)
        {
            Comment comment = _unitOfWork.CommentRepository.Get(id);
            _unitOfWork.CommentRepository.Remove(comment);
            _unitOfWork.SaveChanges();
        }
    }
}
