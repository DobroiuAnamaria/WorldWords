using AutoMapper;
using WebApplication1.Model;

namespace WebApplication1.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
