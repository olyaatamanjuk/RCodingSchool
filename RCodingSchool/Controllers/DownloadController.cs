using StudLine.Services;
using System.Web.Mvc;

namespace StudLine.Controllers
{
    public class DownloadController : Controller
    {
        private readonly FileService _fileService;

        public DownloadController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public ActionResult File(int id)
        {
            var file = _fileService.Get(id);

            return File(file.Location, "application/octet-stream", file.Name);
        }
    }
}