using Newtonsoft.Json;
using RCodingSchool.Services;
using System.Web;
using System.Web.Mvc;

namespace RCodingSchool.Controllers
{
    public class FileController : Controller
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase files)
        {
            var result = _fileService.SaveImages(Request.Files);

            return Content(JsonConvert.SerializeObject(result));
        }
    }
}