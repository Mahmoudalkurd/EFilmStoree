using FluentValidation;
using EBookStore.DTOs;  // Lägg till denna rad

namespace EBookStore.Validators
{
    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(2, 100);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}