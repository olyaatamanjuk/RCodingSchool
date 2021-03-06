﻿using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StudLine.Models;
using StudLine.Services;
using StudLine.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudLine.Controllers
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
            ChaptersListVM chapterListVM = new ChaptersListVM()
            {
                Chapters = Mapper.Map<List<Chapter>, List<ChapterVM>>(chapters),
                SubjectId = id
            };
            return View(chapterListVM);
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
        public ActionResult Topics(int id)
        {
            Topic topic = _chapterService.GetTopicById(id);
            TopicVM topicVM = Mapper.Map<Topic, TopicVM>(topic);

            var res = JsonConvert.SerializeObject(topic, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(res, "application/json");
        }

        [HttpGet]
        public ActionResult CreateTopic(int id)
        {
            TopicVM topicVM = new TopicVM
            {
                ChapterId = id,
                SubjectId = _chapterService.GetById(id).SubjectId
            };

            return View(topicVM);
        }

        [HttpPost]
        public ActionResult CreateChapter(ChapterVM chapterVM)
        {
            if (!string.IsNullOrEmpty(chapterVM.Name))
            {
                _chapterService.AddChapter(chapterVM);
            }

            return RedirectToAction("Chapter", new { id = chapterVM.SubjectId });
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

        [HttpGet]
        public ActionResult EditTopic(int id)
        {
            TopicVM topicVM = Mapper.Map<TopicVM>(_chapterService.GetTopicById(id));
            topicVM.SubjectId = topicVM.Chapter.SubjectId;
            return View(topicVM);
        }

        [HttpPost]
        public ActionResult EditTopic(TopicVM topicVM)
        {
            if (!_chapterService.TryEditTopic(topicVM))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Chapter", new { id = topicVM.SubjectId });
            }
        }

        [HttpGet]
        public void RemoveTopic(int id)
        {
            _chapterService.RemoveTopic(id);
        }

		[HttpGet]
		public void RemoveChapter(int id)
		{
			_chapterService.RemoveChapter(id);
		}

		[HttpGet]
		public void EditChapter(int id, string newName)
		{
			_chapterService.EditChapter(id, newName);
		}
	}
}