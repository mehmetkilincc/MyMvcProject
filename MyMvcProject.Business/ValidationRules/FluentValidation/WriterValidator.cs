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
            RuleFor(writer => writer.WriterName).NotEmpty().WithMessage("Writer Name cannot be empty!")
                                                 .Length(3, 50).WithMessage("‘Name’ must be between 1 and 50 characters!");
            RuleFor(writer => writer.WriterSurname).NotEmpty().WithMessage("Writer Surname cannot be empty!")
                                                   .Length(2, 50).WithMessage("‘Surname’ must be between 2 and 50 characters!");
            RuleFor(writer => writer.WriterAbout).NotEmpty().WithMessage("About cannot be empty!");
            //RuleFor(writer => writer.WriterImage).NotEmpty().WithMessage("Writer image cannot be empty!");
            RuleFor(writer => writer.WriterMail).NotEmpty().WithMessage("Mail address cannot be empty!")
                                                .EmailAddress().WithMessage("Please enter an e-mail address.");
            RuleFor(writer => writer.WriterPassword).NotEmpty().WithMessage("Writer password cannot be empty!");
        }
    }
}
