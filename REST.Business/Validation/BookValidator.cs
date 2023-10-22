using FluentValidation;
using REST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull().WithMessage("BookId is required");
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required");
            RuleFor(x => x.PageCount).NotEmpty().NotNull().WithMessage("Page Count is required");
            RuleFor(x => x.GenreId).NotEmpty().NotNull().WithMessage("GenreId is required");
        }
    }
}
