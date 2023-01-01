using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(writer => writer.WriterName).NotEmpty().WithMessage("Writer Name can not be blank!").Length(3, 50).WithMessage("‘Name’ must be between 1 and 50 characters!");
            RuleFor(writer => writer.WriterSurname).NotEmpty().WithMessage("Writer Surname can not be blank!").Length(2, 50).WithMessage("‘Surname’ must be between 2 and 50 characters!");
            RuleFor(writer => writer.WriterAbout).NotEmpty().WithMessage("Writer about can not be blank!");
            RuleFor(writer => writer.WriterImage).NotEmpty().WithMessage("Writer image can not be blank!");
            RuleFor(writer => writer.WriterMail).NotEmpty().WithMessage("Writer mail can not be blank!").EmailAddress().WithMessage("Please enter an e-mail address.");
            RuleFor(writer => writer.WriterPassword).NotEmpty().WithMessage("Writer password can not be blank!");
        }
    }
}
