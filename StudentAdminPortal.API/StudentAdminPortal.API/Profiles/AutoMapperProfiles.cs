using AutoMapper;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,Student>().ReverseMap();
            CreateMap<Gender,Gender>().ReverseMap();
            CreateMap<Address, Address>().ReverseMap();
        }
    }
}
