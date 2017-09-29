using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RCodingSchool.Services
{
    public class FileService
    {
        public void Save(Models.File file, HttpPostedFileBase postedFile)
        {
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
            var ext = Path.GetExtension(postedFile.FileName);

            if (allowedExtensions.Contains(ext))
            {
                string fullName = file.Id.ToString() + "_" + postedFile.FileName;
                var folderPath = WebConfigurationManager.AppSettings.Get("TopicImagesFolder");

                var path = Path.Combine(folderPath, file.TopicId.ToString(), fullName);

                postedFile.SaveAs(path);
            }
        }
    }
}