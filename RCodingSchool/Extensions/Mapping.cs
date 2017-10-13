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
                .ForMember(d => d.RememberMe, o => o.Ignore());

            CreateMap<Message, MessageVM>();
            CreateMap<Subject, SubjectVM>();
            CreateMap<Chapter, ChapterVM>();
        }
    }
}