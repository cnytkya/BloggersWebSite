using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz");
            RuleFor(x=>x.CategoryName).NotEmpty().MaximumLength(50).WithMessage("Kategori Adı En Fazla 50 Karakter Olmalıdır");
            RuleFor(x=>x.CategoryName).NotEmpty().MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakter Olmalıdır");
        }
    }
}
