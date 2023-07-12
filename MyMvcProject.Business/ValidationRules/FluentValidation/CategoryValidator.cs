using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyMvcProject.Entity.Concrete;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Category name cannot be empty!")
                .MinimumLength(3).WithMessage("Category name must contain a minimum of 3 characters!")
                .MaximumLength(20).WithMessage("Category name  must contain a maximum of 20 characters!");

            RuleFor(category => category.CategoryDescription).NotEmpty().WithMessage("Description cannot be empty!");
        }
    }
}
