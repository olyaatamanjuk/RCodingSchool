using RCodingSchool.Models;
using RCodingSchool.Repositories;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace RCodingSchool.Services
{
    public class FileService : BaseService
    {
        private readonly FileRepository _fileRepository;

        public FileService(FileRepository fileRepository, HttpContextBase httpContext)
            : base(httpContext)
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

        public IEnumerable<FileVM> SaveImages(HttpFileCollectionBase files, Topic topic)
        {
            var newFiles = new List<FileVM>();
            if (files.Count > 0)
            {
                var path = Path.Combine(_httpContext.Server.MapPath("~/App_Data/Topics"), topic.Id.ToString());

                Directory.CreateDirectory(path);

                for (int i = 0; i < files.Count; i++)
                {
                    var file = files.Get(i);
                    var location = Path.Combine(path, file.FileName);
                    file.SaveAs(location);

                    var newFile = _fileRepository.Add(new Models.File
                    {
                        Name = file.FileName,
                        Location = location,
                        TopicId = topic.Id
                    });
                    _fileRepository.SaveChanges();

                    newFiles.Add(new FileVM
                    {
                        Temporary = files.GetKey(i),
                        Id = newFile.Id
                    });
                }
            }

            return newFiles;
        }

        public FileStreamResult GetFile(Models.File file)
        {
            string path = Path.Combine("~/TopicImagesFolder/{0}/{1}", "Topic", file.Topic.Id.ToString(), file.Id.ToString() + file.Name);
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStreamResult result = new FileStreamResult(stream, string.Format(path, Path.GetExtension(file.Id.ToString() + file.Name)));
            result.FileDownloadName = file.Name;
            return result;
        }

        public void SaveTaskFiles(int taskId, IEnumerable<HttpPostedFileBase> files)
        {
            string folderPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/taskFiles"), taskId.ToString());

            Directory.CreateDirectory(folderPath);

            foreach (var file in files.Where(x => x != null))
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);

                    Models.File modelFile = new Models.File();
                    modelFile.Location = path;
                    modelFile.Name = fileName;
                    modelFile.TaskId = taskId;
                    _fileRepository.Add(modelFile);
                }
            }

            _fileRepository.SaveChanges();
        }

        public Models.File Get(int id)
        {
            return _fileRepository.Get(id);
        }
    }
}