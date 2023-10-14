using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly StudentAdminDbContext dbContext;

        public GenderController(StudentAdminDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGender([FromBody] DTO.Gender request)
        {
            //map Dto to domain model
              var gender = new DataModels.Gender {
                Description= request.Description
                };

            await dbContext.Gender.AddAsync(gender);
            await dbContext.SaveChangesAsync();

            //domain model to dto
            var response = new DTO.Gender
            {
                Id = gender.Id,
                Description = gender.Description
            };
            return Ok(response);
            
               


        }
    }
}
