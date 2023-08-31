using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.BlogTContent).NotEmpty().WithMessage("İçerik boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("En az 3 karakter girebilirsiniz");
        }
    }
}
