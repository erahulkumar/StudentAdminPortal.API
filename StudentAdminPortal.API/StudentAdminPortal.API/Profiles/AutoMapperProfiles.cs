using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Profiles.AfterMaps;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Gender,GenderDto>().ReverseMap();
            CreateMap<Address,AddressDto>().ReverseMap();
            CreateMap<UpdateStudentRequest, Student>()
                .AfterMap<UpdateStudentRequestAftermaps>();
        }
    }
}
