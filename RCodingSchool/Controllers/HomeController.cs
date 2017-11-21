using AutoMapper;
using PagedList;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
		private readonly NewsService _newsService;
		private readonly UserService _userService;

		public HomeController(NewsService newsService, UserService userService)
		{
			_newsService = newsService;
			_userService = userService;
		}

		[HttpGet]
		public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public ActionResult News(int page = 1, int pagsize = 4)
		{
			List<News> newsList = _newsService.GetAll().ToList();
			NewsListVM newsListVM = new NewsListVM
			{
				AllNews = Mapper.Map<List<News>, List<NewsVM>>(newsList)
			};
			PagedList<NewsVM> model = new PagedList<NewsVM>(newsListVM.AllNews, page, pagsize);
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
		public ActionResult About()
		{
			return View();
		}

		public ActionResult HerstIndex()
		{
			HerstIndex herstIndex = new RService().AnalizeDataByRange();
			return View(herstIndex);
		}
	}
}