using RCodingSchool.Repositories;
using RCodingSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RCodingSchool.Services
{
    public class FileService
    {
        private readonly FileRepository _fileRepository;

        public FileService(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

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

        public IEnumerable<FileVM> SaveImages(HttpFileCollectionBase files)
        {
            var newFiles = new List<FileVM>();
            for (int i = 0; i < files.Count; i++)
            {
                var file = files.Get(i);
                var fileLocation = $"{Guid.NewGuid().ToString()}.{file.FileName}";
                var path = Path.Combine(WebConfigurationManager.AppSettings.Get("TopicImagesFolder"), "Temp", fileLocation);
                file.SaveAs(path);

                var dbFile = _fileRepository.Add(new Models.File
                {
                    Name = file.FileName,
                    Location = fileLocation
                });

                newFiles.Add(new FileVM
                {
                    Id = dbFile.Id,
                    Templorary = files.GetKey(i)
                });
            }

            return newFiles;
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