using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        /* [HttpPost]
public async Task<IActionResult> CreateStudent(StudentRequestDto request)
{
//map dto to domain model
var student = new Student
{
FirstName = request.FirstName,
LastName = request.LastName,
DateOfBirth= request.DateOfBirth,
Email= request.Email,
Moblie= request.Moblie,
ProfileImageUrl= request.ProfileImageUrl,
GenderId= request.GenderId,
Gender= request.Gender,
Address= request.Address

};
}*/
        public StudentController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await studentRepository.GetStudentAsync();

            //return Ok(studentRepository.GetStudent());
            return Ok(mapper.Map<List<Student>>(students));

            /*var DomainResponse = new List<Student>();
            foreach (var student in students)
            {
                DomainResponse.Add(new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Gender = new Gender()
                    {
                        Id = student.GenderId,
                        Description = student.Gender.Description
                    },
                    Address = new Address()
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress,
                    }

                });
            }
            return Ok(DomainResponse);*/
        }
    }
}
