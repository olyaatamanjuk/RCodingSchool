using RCodingSchool.Models;
using RCodingSchool.Repositories;
using RCodingSchool.Interfaces;
using System;

namespace RCodingSchool.UnitOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false;
        private readonly RCodingSchoolContext _dbContext;
        private IUserRepository _userRepository;
        private IChapterRepository _chapterRepository;
        private ICommentRepository _commentRepository;
        private IFileRepository _fileRepository;
        private IGroupRepository _groupRepository;
        private IMessageRepository _messageRepository;
        private INewsRepository _newsRepository;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;
        private ITaskRepository _taskRepository;
        private ITeacherRepository _teacherRepository;
        private ITopicRepository _topicRepository;

        public IChapterRepository ChapterRepository
        {
            get
            {
                if (_chapterRepository == null)
                {
                    _chapterRepository = new ChapterRepository(_dbContext);
                }

                return _chapterRepository;
            }
        }
        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_dbContext);
                }

                return _commentRepository;
            }
        }
        public IFileRepository FileRepository
        {
            get
            {
                if (_fileRepository == null)
                {
                    _fileRepository = new FileRepository(_dbContext);
                }

                return _fileRepository;
            }
        }
        public IGroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository == null)
                {
                    _groupRepository = new GroupRepository(_dbContext);
                }

                return _groupRepository;
            }
        }
        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_dbContext);
                }

                return _messageRepository;
            }
        }
        public INewsRepository NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_dbContext);
                }

                return _newsRepository;
            }
        }
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_dbContext);
                }

                return _studentRepository;
            }
        }
        public ISubjectRepository SubjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                {
                    _subjectRepository = new SubjectRepository(_dbContext);
                }

                return _subjectRepository;
            }
        }
        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_dbContext);
                }

                return _taskRepository;
            }
        }
        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_dbContext);
                }

                return _teacherRepository;
            }
        }
        public ITopicRepository TopicRepository
        {
            get
            {
                if (_topicRepository == null)
                {
                    _topicRepository = new TopicRepository(_dbContext);
                }

                return _topicRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }

                return _userRepository;
            }
        }

        public UnitOfWork(RCodingSchoolContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}