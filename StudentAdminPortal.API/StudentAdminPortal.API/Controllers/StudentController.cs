using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public StudentController(IStudentRepository studentRepository,IMapper mapper
            , IImageRepository imageRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<DataModels.Student>>(students));

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
        [HttpGet]
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            //fetch student details
            var student = await studentRepository.GetStudentAsync(studentId);

            //Return
            if (student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DataModels.Student>(student));
        }
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if(await studentRepository.Exists(studentId))
            {
                //Update Details

                var updatedStudent = await studentRepository.UpdateStudent(studentId,mapper.Map<DataModels.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(mapper.Map<DataModels.Student>(updatedStudent));
                }
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
                //Delete Student
                var student =await studentRepository.DeleteStudentAsync(studentId);
                return Ok(mapper.Map<StudentDto>(student));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var student = await studentRepository.AddStudentAsync(mapper.Map<DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync),new {studentId = student.Id},
                mapper.Map<DataModels.Student>(student)); 
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            var validExtensions=new List<string>
            {
                ".jpeg",".png",".jpg",".gif"
            };
            if(profileImage != null && profileImage.Length>0)
            {
                var extension=Path.GetExtension(profileImage.FileName);
                if(validExtensions.Contains(extension))
                 {
                    //Check if student exists
                    if (await studentRepository.Exists(studentId))
                    {
                        var fileName= Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                        //upload the image to local storage
                        var fileImagePath = await imageRepository.Upload(profileImage, fileName);
                        //upload the profile image path in the database
                        if (await studentRepository.UpdateProfileImage(studentId, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }  
                }
                return BadRequest("This is not a valid image format");
            }
            return NotFound();
        }
    }
}
