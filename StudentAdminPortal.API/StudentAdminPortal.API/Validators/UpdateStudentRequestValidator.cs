using FluentValidation;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).NotEmpty().GreaterThan(6000000000).LessThan(10000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepository.GetGendersAsync().Result.ToList().
                FirstOrDefault(x => x.Id == id);

                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid Gender");
            RuleFor(x => x.PostalAddress).NotEmpty();
            RuleFor(x => x.PhysicalAddress).NotEmpty();
        }
    }
}
