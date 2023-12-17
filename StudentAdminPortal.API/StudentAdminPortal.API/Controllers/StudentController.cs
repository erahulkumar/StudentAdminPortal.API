using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await studentRepository.GetStudentAsync();

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
                    Moblie = student.Mobile,
                    Email = student.Email,
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
                        StudentId = student.Id

                    }

                });
            }
            return Ok(DomainResponse);*/
        }
        /*[HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var existingStudentId = await studentRepository.GetStudentsByIdAsync(Id);
            if (existingStudentId != null)
            {
                return NotFound();
            }
            var response = new StudentDto
            {
                Id = Id,
                FirstName = existingStudentId.FirstName,
                LastName = existingStudentId.LastName,
                DateOfBirth = existingStudentId.DateOfBirth,
                Email = existingStudentId.Email,
                Moblie = existingStudentId.Mobile,
                ProfileImageUrl = existingStudentId.ProfileImageUrl,
                GenderId = existingStudentId.GenderId,
                Gender = new GenderDto
                {
                    Id = existingStudentId.GenderId,
                    Description = existingStudentId.Gender.Description
                },
                Address = new AddressDto
                {
                    Id = existingStudentId.Address.Id,
                    PhysicalAddress = existingStudentId.Address.PhysicalAddress,
                    PostalAddress = existingStudentId.Address.PostalAddress,
                    StudentId = existingStudentId.Id
                }
            };
            return Ok(response);

        }*/
    }
}
