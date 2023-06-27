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
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!")
                .MinimumLength(3).WithMessage("Kategori adı minimum 3 karakter olmalıdır!")
                .MaximumLength(20).WithMessage("Kategori adı maksimum 20 karakter olabilir!");

            RuleFor(category => category.CategoryDescription).NotEmpty().WithMessage("Kategori tanımı Boş Geçilemez").EmailAddress();
        }
    }
}
