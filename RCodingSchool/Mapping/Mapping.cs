using AutoMapper;
using RCodingSchool.Mapping.ModelsVM;
using RCodingSchool.Models;
using RCodingSchool.Session;

namespace RCodingSchool.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserVM>()
            .ForMember(d => d.RememberMe, o => o.Ignore());
            CreateMap<User, UserContext>();
            CreateMap<Message, MessageVM>();

        }
    }
}