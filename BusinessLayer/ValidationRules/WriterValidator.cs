using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Boş Geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En Az 3 Karakter Giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Alanı Boş Geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Alanı Boş Geçilemez");
        }
    }
}
