using RCodingSchool.Models;
using RCodingSchool.Interfaces;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RCodingSchool.Services
{
	public class NewsService : BaseService
	{
		private readonly INewsRepository _newsRepository;
		private readonly ICommentRepository _commentRepository;
	

		public NewsService(INewsRepository newsRepository, ICommentRepository commentRepositpry, HttpContextBase httpContext) 
			:base(httpContext)
		{
			_newsRepository = newsRepository;
			_commentRepository = commentRepositpry;
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
	}
}
