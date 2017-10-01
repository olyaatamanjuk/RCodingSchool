using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RCodingSchool.Services
{
    public class FileService
    {
        public void SaveImage(Models.File file, HttpPostedFileBase postedFile)
        {
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
            var ext = Path.GetExtension(postedFile.FileName);

            if (allowedExtensions.Contains(ext))
            {
                string fullName = file.Id.ToString() + "_" + postedFile.FileName;
                var generalFolderPath = WebConfigurationManager.AppSettings.Get("TopicImagesFolder");
				var folderPath = Path.Combine(generalFolderPath, file.TopicId.ToString());
				if (!(Directory.Exists(folderPath)))
				{
					DirectoryInfo directory = Directory.CreateDirectory(folderPath);
				}

				var path = Path.Combine(folderPath, file.TopicId.ToString(), fullName);
                postedFile.SaveAs(path);
            }
        }
		public FileStreamResult GetFile(Models.File file)
		{
			string path = Path.Combine("~/TopicImagesFolder/{0}/{1}", "Topic", file.Topic.Id.ToString(), file.Id.ToString()+ file.Name);
			FileStream stream = new FileStream(path, FileMode.Open);
			FileStreamResult result = new FileStreamResult(stream, string.Format(path, Path.GetExtension(file.Id.ToString() + file.Name)));
			result.FileDownloadName = file.Name;
			return result;
		}
	}
}