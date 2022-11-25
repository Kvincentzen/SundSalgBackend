using AutoMapper;
using SundSalgBackend.Models.DataTransferObjects;
using SundSalgBackend.Models;

namespace SundSalgBackend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
            CreateMap<Counselor, CounselorDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<UserProfileDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
