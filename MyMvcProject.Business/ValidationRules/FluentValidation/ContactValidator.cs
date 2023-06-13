using FluentValidation;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class ContactValidator :AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.UserMail).NotEmpty().WithMessage("User mail cannot be blank!");
            RuleFor(contact => contact.UserName).NotEmpty().WithMessage("User name cannot be blank!");
            RuleFor(contact => contact.Subject).NotEmpty().WithMessage("Subject cannot be blank!")
                                               .MinimumLength(3).WithMessage("Min 3 character!")
                                               .MaximumLength(50).WithMessage("Max 50 character!");
            RuleFor(contact => contact.Message).NotEmpty().WithMessage("Message cannot be blank!");
        }
    }
}
