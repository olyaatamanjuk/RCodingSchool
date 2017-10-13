using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class ChapterController: Controller
    {
        private readonly ChapterService _chapterService;
        public ChapterController(ChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        // GET: Subject
        public ActionResult Chapter()
        {
            List<Chapter> chapters = _chapterService.GetList();
            List<ChapterVM> chaptersVM = Mapper.Map<List<Chapter>, List<ChapterVM>>(chapters);
            return View(chaptersVM);
        }
    }
}