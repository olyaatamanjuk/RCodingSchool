﻿using AutoMapper;
using PagedList;
using StudLine.Models;
using StudLine.Services;
using StudLine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudLine.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly NewsService _newsService;
		private readonly UserService _userService;
		private readonly FileService _fileService;
		private readonly RService _RService;

		public HomeController(NewsService newsService, UserService userService, FileService fileService, RService RService)
		{
			_newsService = newsService;
			_userService = userService;
			_fileService = fileService;
			_RService = RService;
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult News(int page = 1, int pagsize = 4, int month = -1)
		{
			List<News> newsList = new List<News>();
			if (month == -1)
			{
				newsList = _newsService.GetAll().ToList();
			}
			else
			{
				newsList = _newsService.GetByMonth(month);
			}
			List<NewsVM> newsListVM = Mapper.Map<List<News>, List<NewsVM>>(newsList);
			PagedList<NewsVM> model = new PagedList<NewsVM>(newsListVM, page, pagsize);
			return View(model);
		}

		[HttpGet]
		public ActionResult NewsDetail(int? id)
		{
			News news = _newsService.Get(id.GetValueOrDefault());
			NewsVM newsVM = Mapper.Map<News, NewsVM>(news);
			return View(newsVM);
		}

		[HttpPost]
		public ActionResult NewsDetail(NewsVM newsVM)
		{
			if (_newsService.TrySave(newsVM))
			{
				return RedirectToAction("NewsDetail", new { id = newsVM.Id });
			}
			else
			{
				return View();
			}
		}

		[HttpGet]
		public ActionResult CreateNews()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateNews(NewsVM newsVM)
		{
			if (_newsService.TrySaveNews(newsVM))
			{
				return RedirectToAction("News");
			}
			else
			{
				ModelState.AddModelError("validValues", "Перевірте на заповненість поля");
				return View();
			}
		}

		[HttpGet]
		public ActionResult EditNews(int id)
		{
			NewsVM newsVM = Mapper.Map<NewsVM>(_newsService.Get(id));
			return View(newsVM);
		}

		[HttpPost]
		public ActionResult EditNews(NewsVM newsVM)
		{
			if (_newsService.TryEditNews(newsVM))
			{
				return RedirectToAction("News");
			}
			else
			{
				ModelState.AddModelError("validValues", "Перевірте на заповненість поля");
				return View();
			}
		}

		public ActionResult RemoveNews(int id)
		{
			_newsService.RemoveNews(id);
			return RedirectToAction("News");
		}

		public ActionResult RemoveComment(int commentId, int newsId)
		{
			_newsService.RemoveComment(commentId);
			return RedirectToAction("NewsDetail", new { id = newsId });
		}

		[HttpGet]
		public ActionResult About()
		{
			return View();
		}

		[HttpGet]
		public ActionResult HerstIndex()
		{
			var model = TempData["Results"] as HerstIndex;
			if (model!= null && model.H == null)
			{
				ModelState.AddModelError("validValues", "Ви ввели недопустимі значення параметрів");
				return View();
			}
			else
			{
				return View(model);
			}
		}

		[HttpPost]
		public ActionResult HerstIndex(HttpPostedFileBase file, HerstIndex herstIndex)
		{
			if (herstIndex.N == 0 || herstIndex.K == 0)
			{
				ModelState.AddModelError("validValues", "Ви ввели недопустимі значення");
				return View();
			}
			string filePath = _fileService.TrySaveDataFile(file);
			HerstIndex herstIndexResult = new HerstIndex();
			if (!String.IsNullOrWhiteSpace(filePath))
			{
				herstIndexResult = _RService.AnalizeDataByRange(herstIndex.N.ToString(), herstIndex.K.ToString());
				TempData["Results"] = herstIndexResult;
			}

			return RedirectToAction("HerstIndex");
		}

		[HttpGet]
		public ActionResult Сongratulation()
		{
			return View();
		}
	}
}