using FluentValidation;
using REST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty().NotNull().WithMessage("AuthorId is required");
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("LastName is required");
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("DateOfBirth is required");
        }
    }
}
