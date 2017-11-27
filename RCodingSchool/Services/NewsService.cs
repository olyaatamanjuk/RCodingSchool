using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using AutoMapper;

namespace RCodingSchool.Services
{
	public class NewsService : BaseService
	{
		private readonly INewsRepository _newsRepository;
		private readonly ICommentRepository _commentRepository;
		private readonly IUserRepository _userRepository;


		public NewsService(INewsRepository newsRepository, ICommentRepository commentRepositpry, IUserRepository userRepository, HttpContextBase httpContext) 
			:base(httpContext)
		{
			_newsRepository = newsRepository;
			_commentRepository = commentRepositpry;
			_userRepository = userRepository;
		}

		public News Get(int id)
		{
			return _newsRepository.Get(id);
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
				_commentRepository.Add(comment);
				_commentRepository.SaveChanges();
			}
			return true;
		}

		public IEnumerable<News> GetAll()
		{
			return _newsRepository.GetAll();
		}

		public bool TrySaveNews (NewsVM newsVM)
		{
			News news = Mapper.Map<News>(newsVM);
			if ( !String.IsNullOrWhiteSpace(news.Title) && !String.IsNullOrWhiteSpace(news.Description))
			{
				news.Date = DateTime.Now;
				news.NewsAuthorId = _userRepository.GetActualUserById<Teacher>(UserId).Id;
				_newsRepository.Add(news);
				_newsRepository.SaveChanges();
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
				_newsRepository.SaveChanges();
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
			_newsRepository.Remove(news);
			_newsRepository.SaveChanges();
		}

		public void RemoveComment(int id)
		{
			Comment comment = _commentRepository.Get(id);
			_commentRepository.Remove(comment);
			_commentRepository.SaveChanges();
		}
	}
}
