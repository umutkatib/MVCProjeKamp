﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En Az 3 Karakter Giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En Fazla 20 Karakter Giriniz");
        }
    }
}
