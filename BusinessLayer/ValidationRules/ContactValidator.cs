using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("En az 5 karakter girilebir.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girilebir.");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("En fazla 500 karakter girilebir.");
        }
    }
}
