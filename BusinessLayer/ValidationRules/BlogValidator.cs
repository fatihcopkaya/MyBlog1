using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Haber başlığı boş olamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Haber içeriği boş olamaz");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Haber başlığı 150 karakterden fazla olamaz");
            RuleFor(x=>x.BlogTitle).MinimumLength(15).WithMessage("Haber Başlığı 15 karakterden az olamaz"); 

        }
    }
}