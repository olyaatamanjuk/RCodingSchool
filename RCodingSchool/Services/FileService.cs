using RCodingSchool.UnitOW;
using RCodingSchool.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RCodingSchool.Services
{
    public class FileService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FileService(IUnitOfWork unitOfWork, HttpContextBase httpContext)
            : base(httpContext)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<FileVM> SaveImages(HttpFileCollectionBase files, int topicId)
        {
            var newFiles = new List<FileVM>();
            if (files.Count > 0)
            {
                var path = Path.Combine(_httpContext.Server.MapPath("~/App_Data/Topics"), topicId.ToString());

                Directory.CreateDirectory(path);

                for (int i = 0; i < files.Count; i++)
                {
                    var file = files.Get(i);
                    var location = Path.Combine(path, file.FileName);
                    file.SaveAs(location);

                    var newFile = _unitOfWork.FileRepository.Add(new Models.File
                    {
                        Name = file.FileName,
                        Location = location,
                        TopicId = topicId
                    });
                    _unitOfWork.SaveChanges();

                    newFiles.Add(new FileVM
                    {
                        Temporary = files.GetKey(i),
                        Id = newFile.Id
                    });
                }
            }

            return newFiles;
        }

        public void DeleteImages(TopicVM topic)
        {
            var oldFiles = _unitOfWork.FileRepository.GetByTopicId(topic.Id);

            foreach (var file in oldFiles)
            {
                if (!topic.Text.Contains("Download/File/" + file.Id))
                {
                    _unitOfWork.FileRepository.Remove(file);
                }
            }

            _unitOfWork.SaveChanges();
        }

        public string TrySaveDataFile(HttpPostedFileBase file)
        {
            string folderPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/R"), "Calculate");
            string path = "";

            Directory.CreateDirectory(folderPath);

            if (file != null && file.ContentLength > 0)
            {
                string fileNameWithEx = Path.GetFileName(file.FileName);
                string fileName = Path.GetFileNameWithoutExtension(fileNameWithEx);
                string resultName = fileNameWithEx.Replace(fileName, "TestData");
                path = Path.Combine(folderPath, resultName);
                file.SaveAs(path);
            }

            return path;
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
                    _unitOfWork.FileRepository.Add(modelFile);
                }
            }

            _unitOfWork.SaveChanges();
        }

        public void SaveDoneTaskFiles(int taskId, int doneTaskId, IEnumerable<HttpPostedFileBase> files)
        {
            string folderPath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/taskFiles"), taskId.ToString(), "done", doneTaskId.ToString());

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
                    modelFile.DoneTaskId = doneTaskId;
                    _unitOfWork.FileRepository.Add(modelFile);
                }
            }

            _unitOfWork.SaveChanges();
        }

        public Models.File Get(int id)
        {
            return _unitOfWork.FileRepository.Get(id);
        }

        public void RemoveImages(int topicId)
        {
            foreach (var file in _unitOfWork.FileRepository.GetByTopicId(topicId))
            {
                _unitOfWork.FileRepository.Remove(file);
            }
            _unitOfWork.SaveChanges();
        }
    }
}