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
	public class NewsService
	{
		private readonly INewsRepository _newsRepository;
		private readonly ICommentRepository _commentRepository;
		private HttpContextBase _httpContext;

		public NewsService(INewsRepository newsRepository, ICommentRepository commentRepositpry, HttpContextBase httpContext)
		{
			_newsRepository = newsRepository;
			_commentRepository = commentRepositpry;
			_httpContext = httpContext;
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
