using AutoMapper;
using RCodingSchool.Models;
using RCodingSchool.ViewModels;

namespace RCodingSchool.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
			CreateMap<User, UserVM>()
				.ForMember(d => d.RememberMe, o => o.Ignore())
				.ForMember(d => d.ConfirmPassword, o => o.Ignore())
				.ForMember(d => d.GroupName, o => o.Ignore())
				.ForMember(d => d.IsTeacher, o => o.Ignore());

            CreateMap<Message, MessageVM>();

            CreateMap<Subject, SubjectVM>();

            CreateMap<Chapter, ChapterVM>()
				.ForMember(d => d.CurrentTopicId, o=> o.Ignore());

			CreateMap<Topic, TopicVM>();

			CreateMap<News, NewsVM>()
				.ForMember(d => d.CommentText, o => o.Ignore());
		}
    }
}