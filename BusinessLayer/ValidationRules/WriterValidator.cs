using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi apın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Location).MaximumLength(30).WithMessage("En fazla 30 karakter girebilirsiniz");
            RuleFor(x => x.Location).MinimumLength(2).WithMessage("En az 2 karakter girebilirsiniz");
        }
    }
}
