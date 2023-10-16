using AutoMapper;
using DataModel = StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModel.Student,Student>().ReverseMap();
            CreateMap<DataModel.Gender,Gender>().ReverseMap();
            CreateMap<DataModel.Address,Address>().ReverseMap();
        }
    }
}
