using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

 namespace BusinessLayer.ValidationRules
 {
     public class WriterValidator : AbstractValidator<Writer>
    {
         public WriterValidator()
         {
             RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim boş bıraklılamaz");
             RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısmı boş bırakılamaz"); 
             RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş bırakılamaz");
             RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("İsim en az iki karakterli olmalıdır");
             RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır");
// 
         }
    }
}