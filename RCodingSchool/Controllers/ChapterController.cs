using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.Services;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    [Authorize]
    public class ChapterController : Controller
    {
        private readonly ChapterService _chapterService;

        public ChapterController(ChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet]
        public ActionResult Chapter(int id)
        {
            List<Chapter> chapters = _chapterService.GetListChaptersBySubjectId(id);
            List<ChapterVM> chaptersVM = Mapper.Map<List<Chapter>, List<ChapterVM>>(chapters);

            return View(chaptersVM);
        }

        [HttpGet]
        public ActionResult Topic(TopicVM topicVM)
        {
            if (topicVM == null)
            {
                return PartialView(Mapper.Map<Topic, TopicVM>(_chapterService.GetFirstTopicFromChaper(_chapterService.GetFirstChapter().Id)));
            }
            else
            {
                return PartialView(topicVM);
            }
        }

        [HttpPost]
        [ActionName("topic")]
        public ActionResult topics(int id)
        {
            Topic topic = _chapterService.GetTopicById(id);
            TopicVM topicVM = Mapper.Map<Topic, TopicVM>(topic);

            return PartialView(topicVM);
        }

        [HttpGet]
        public ActionResult CreateTopic(int id)
        {
            TopicVM topicVM = new TopicVM();
            topicVM.ChapterId = id;
            topicVM.SubjectId = _chapterService.GetById(id).SubjectId;

            return View(topicVM);
        }

        [HttpPost]
        public ActionResult CreateTopic(TopicVM topicVM)
        {
            if (_chapterService.TrySaveTopic(topicVM))
            {
                return RedirectToAction("Chapter", "Chapter", new { id = topicVM.SubjectId });
            }
            else
            {
                ModelState.AddModelError("credentials", "Перевірте, будь ласка, на заповненість поля.");
                return View(topicVM);
            }
        }
    }
}