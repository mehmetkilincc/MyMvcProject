
using FluentValidation;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(contact => contact.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(contact => contact.Surname).NotEmpty().WithMessage("Surname cannot be empty!");
            RuleFor(contact => contact.Email).NotEmpty().WithMessage("Email cannot be empty!");
            RuleFor(admin => admin.UserName).NotEmpty().WithMessage("Username cannot be empty!")
                                            .MinimumLength(5).WithMessage("Username must contain a minimum of 5 characters!")
                                            .MaximumLength(50).WithMessage("Username must contain a maximum of 50 characters!");
            RuleFor(admin => admin.Password).NotEmpty().WithMessage("Password cannot be empty!")
                                            .MinimumLength(1).WithMessage("Password must contain a minimum of 1 characters.")
                                            .MaximumLength(50).WithMessage("Password must contain a maximum of 50 characters.");
            RuleFor(admin => admin.Role).NotEmpty().WithMessage("Role cannot be empty!");
        }
    }
}
