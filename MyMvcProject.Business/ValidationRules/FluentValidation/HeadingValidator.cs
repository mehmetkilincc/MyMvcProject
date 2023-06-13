using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            //RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Heading name cannot be blank!");
            //RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Name cannot be empty!");

        }
    }
}
