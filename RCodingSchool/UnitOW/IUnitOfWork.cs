using RCodingSchool.Interfaces;
using System;

namespace RCodingSchool.UnitOW
{
    public interface IUnitOfWork : IDisposable
    {
        IChapterRepository ChapterRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFileRepository FileRepository { get; }
        IGroupRepository GroupRepository { get; }
        IMessageRepository MessageRepository { get; }
        INewsRepository NewsRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITaskRepository TaskRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ITopicRepository TopicRepository { get; }
        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}