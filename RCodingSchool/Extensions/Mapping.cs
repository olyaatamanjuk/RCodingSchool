using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.ViewModels;

namespace RCodingSchool.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Model -> ViewModel
            CreateMap<User, UserVM>()
                .ForMember(d => d.RememberMe, o => o.Ignore())
                .ForMember(d => d.ConfirmPassword, o => o.Ignore())
                .ForMember(d => d.GroupId, o => o.Ignore())
                .ForMember(d => d.IsTeacher, o => o.Ignore())
                .ForMember(d => d.Categories, o => o.Ignore());

            CreateMap<Message, MessageVM>();

            CreateMap<Subject, SubjectVM>();

            CreateMap<Student, StudentVM>();

            CreateMap<Task, TaskVM>();

			CreateMap<DoneTask, DoneTaskVM>();

			CreateMap<Teacher, TeacherVM>();

            CreateMap<Group, GroupVM>();

			CreateMap<ChapterVM, Chapter>();

			CreateMap<Chapter, ChapterVM>()
				.ForMember(d => d.CurrentTopicId, o=> o.Ignore());

            CreateMap<Topic, TopicVM>();

            CreateMap<News, NewsVM>()
                .ForMember(d => d.CommentText, o => o.Ignore());

            // ViewModel -> Model 
            CreateMap<TopicVM, Topic>();
        }
    }
}